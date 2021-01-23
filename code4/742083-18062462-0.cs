    private class FolderRow
        {
            public int Indent
            {
                get { return this.Row.GetValue("Indent", 0); }
                set { this.Row["Indent"] = value; }
            }
            public int Left
            {
                get { return this.Row.GetValue("Tree L", 0); }
                set { this.Row["Tree L"] = value; }
            }
            public int Right
            {
                get { return this.Row.GetValue("Tree R", 0); }
                set { this.Row["Tree R"] = value; }
            }
            public Guid Id
            {
                get { return this.Row.GetValue("FolderID", Guid.Empty); }
                
            }
            public DataRow Row { get; private set; }
            public int RowNum { get; set; }
            public bool RowComplete { get { return this.Left > 0 && this.Right > 0; } }
            public FolderRow(DataRow row, int rowNum)
            {
                this.Row = row;
                this.RowNum = rowNum;
            }
        }    
    [TestMethod]
    public void ImportFolderStructure()
    {
    	var inputTable = FileUtil.GetDataSetFromExcelFile(new FileInfo(@"c:\SampleTree.xlsx")).Tables[0];
    
    	var currentLevel = 0;
    	var nodeCount = 1;
    	var currentRow = 0;
    
    	inputTable.Columns.Add("Indent", typeof (int));
    	inputTable.Columns.Add("Path", typeof (string));
    
    	var rightStack = new List<FolderRow>();
    
    	foreach (DataRow row in inputTable.Rows)
    		row["Indent"] = GetLevelPopulated(row);
    
    	foreach (DataRow row in inputTable.Rows)
    	{
    		if (row.GetValue("Indent", 0) == 0)
    			row["Tree L"] = 1;                
    
    	}
    
    	while (true)
    	{
    		var row = GetRow(inputTable, currentRow);
    		if (row.Indent == 0)
    		{
    			currentRow++;
    			rightStack.Add(row);
    			continue; 
    		}
    
    		// if the indent of this row is greater than the previous row ...
    		if (row.Indent > currentLevel)
    		{
    			currentLevel++;
    			nodeCount++;
    			row.Left = nodeCount;
    			// ... check the next row to see if it is further indented
    			currentRow = HandleNextRow(row, currentRow, rightStack, inputTable, ref currentLevel, ref nodeCount);
    		} else if (row.Indent == currentLevel)
    		{
    			nodeCount++;
    			row.Left = nodeCount;
    			currentRow = HandleNextRow(row, currentRow, rightStack, inputTable, ref currentLevel, ref nodeCount);
    		} else if (row.Indent < currentLevel)
    		{
    			currentLevel--;
    			nodeCount++;
    			row.Left = nodeCount;
    			currentRow = HandleNextRow(row, currentRow, rightStack, inputTable, ref currentLevel, ref nodeCount);
    		}
    
    		if (inputTable.Rows.Cast<DataRow>().Select(r => new FolderRow(r, -1)).All(r => r.RowComplete))
    			break;
    
    	}
    
    }
    
    private int HandleNextRow(FolderRow row, int currentRow, List<FolderRow> rightStack, DataTable inputTable, ref int currentLevel,
    						  ref int nodeCount)
    {
    	var nextRow = GetRow(inputTable, currentRow + 1);
    	if (nextRow != null)
    	{
    		if (nextRow.Indent > row.Indent)
    		{
    			// ok the current row has a child so we will need to set the tree right of that, add to stack
    			rightStack.Add(row);
    		}
    		else if (nextRow.Indent == row.Indent)
    		{
    			nodeCount++;
    			row.Right = nodeCount;
    		}
    		else if (nextRow.Indent < row.Indent)
    		{
    			nodeCount++;
    			row.Right = nodeCount;
    			nodeCount++;
    			// here we need to get the most recently added row to rightStack, set the Right to the current nodeCount
    			var stackLast = rightStack.LastOrDefault();
    			if (stackLast != null)
    			{
    				stackLast.Right = nodeCount;
    				rightStack.Remove(stackLast);
    			}
    
    			currentLevel--;
    		}
    
    		currentRow++;
    
    		if (rightStack.Count > 1)
    		{
    			// before we move on to the next row, we need to check if there is more than one row still in right stack and 
    			// the new current row's ident is less than the current branch (not current leaf)
    			var newCurrentRow = GetRow(inputTable, currentRow);
    			var stackLast = rightStack.LastOrDefault();
    			if (newCurrentRow.Indent == stackLast.Indent)
    			{
    				nodeCount++;
    				stackLast.Right = nodeCount;
    				rightStack.Remove(stackLast);
    				
    			}
    		}
    		
    
    	}
    	else
    	{
    		// reached the bottom
    		nodeCount++;
    		row.Right = nodeCount;
    
    		// loop through the remaining items in rightStack and set their right values
    		var stackLast = rightStack.LastOrDefault();
    		while (stackLast != null)
    		{
    			nodeCount++;
    			stackLast.Right = nodeCount;
    			rightStack.Remove(stackLast);
    			stackLast = rightStack.LastOrDefault();
    		}
    	}
    	return currentRow;
    }
    
    private FolderRow GetRow(DataTable inputTable, int rowCount)
    {
    	if (rowCount >= inputTable.Rows.Count)
    		return null;
    
    	return rowCount < 0 ? null : new FolderRow(inputTable.Rows[rowCount],rowCount);
    }
    
    private int GetLevelPopulated(DataRow row)
    {
    	var level = 0;
    
    	while (level < 14)
    	{
    		if (level == 0 && row["Root"] != DBNull.Value)
    			return level;
    
    		level++;
    
    		if (row["Level " + level] != DBNull.Value)
    			return level;
    	}
    
    	return -1;
    }
