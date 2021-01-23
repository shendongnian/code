    class QueryClass
    {
    	public QueryClass()
    	{
    	recipiesNewDataSet recipiesNewDataSet = new recipiesNewDataSet();
    
    	recipiesNewDataSetTableAdapters.IngredientTableAdapter ingredientTableAdapter = new recipiesNewDataSetTableAdapters.IngredientTableAdapter();
    
    	ingredientTableAdapter.Fill(recipiesNewDataSet);
    	}
    }
