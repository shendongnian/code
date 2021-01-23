    private void assignProductCategory(string AcStockCategoryID) 
    {
        string[] splitParameter = AcStockCategoryID.Split('-');
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        
        sb.AppendLine("gender=" + splitParameter[0].Substring(0, 1));
        sb.AppendLine("Product=" + splitParameter[0].Substring(1));
        sb.AppendLine("Category=" + splitParameter[1]);
     
        // use sb.ToString() wherever you need the results
    }
