    /// <summary>
    /// Checks if a category has fulfilled the requirements for # of sub categories and adds the missing sub categories, if needed
    /// </summary>
    private void CheckSubCategoryRequirements(DataTable dtResults)
    {
    	if (subCategoryOccurences< subCategories.Length)
    	{
    		//we need to add rows for the missing subcategories
    		while (subCategoryOccurences< subCategories.Length)
    		{
    			//create a new row and populate category and subcategory info
    			rowFiller = dtResults.NewRow();
    			rowFiller["Category"] = categoryPrevious;
    			rowFiller["SubCategory"] = subCategories[subCategoryOccurences];
    			//insert the new row into the current location of table 
    			dtResults.Rows.InsertAt(rowFiller, rowCount);
    			subCategoryOccurences++;
    			rowCount++;
    		}
    	}
    }
