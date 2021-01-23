    private void assignProductCategory(string AcStockCategoryID) 
    {
        string[] splitParameter = AcStockCategoryID.Split('-');
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        
        sb.AppendLine("gender=" + splitParameter[0]);
        sb.AppendLine("Product=" + splitParameter[1]);
        sb.AppendLine("Category=" + splitParameter[2]);
     
        // use sb.ToString() wherever you need the results
    }
