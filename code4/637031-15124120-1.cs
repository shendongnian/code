    public void PrepareDataTable(DataTable dtResults)
    {
    
    	if (dtResults == null || dtResults.Rows.Count == 0)
    		return;
    
    	//initialize category
    	categoryPrevious = dtResults.Rows[0]["Category"].ToString();
    	do
    	{
    		//get the current category
    		categoryCurrent = dtResults.Rows[rowCount]["Category"].ToString();
    		//check if this is a new category. this is where all the work is done
    		if (categoryCurrent != categoryPrevious)
    		{
    			//check if we have fulfilled the requirement for number of subcategories 
    			CheckSubCategoryRequirements(dtResults);
    			//at this point we have fulfilled the requirement for number of subcategories 
    			//add blank (separator) row
    			dtResults.Rows.InsertAt(dtResults.NewRow(), rowCount);
    			rowCount++;
    			//reset the number of subcategories
    			subCategoryOccurences = 0;
    			categoryPrevious = categoryCurrent;
    		}
    		else
    		{
    			rowCount++;
    			categoryOccurences++;
    		}
    	} while (rowCount < dtResults.Rows.Count);
    	//check sub category requirements for the last category
    	CheckSubCategoryRequirements(dtResults);
    
    }
