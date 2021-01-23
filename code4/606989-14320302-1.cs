    void radGridView_CellFormatting(object sender, CellFormattingEventArgs  e) 		
    { 
        // For all cells under the Account Name column
    	if(e.CellElement.ColumnInfo.Name == "Account Name")
    	{
    		if(e.CellElement.Value != null)
    		{
    		    System.Drawing.Font newfontsize = new System.Drawing.Font(e.CellElement.Font.FontFamily.Name,20);
    
    		    for each(GridViewCellInfo cell in e.Row.Cells)
    			{
    			    e.CellElement.Font = newfontsize;
    			}
    			
    		}
    	}
        // For all other cells under other columns
        else
        {
            e.CellElement.ResetValue(Telerik.WinControls.UI.LightVisualElement.Font, Telerik.WinControls.ValueResetFlags.Local);
        }
    }
