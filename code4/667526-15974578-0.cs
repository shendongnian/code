    //create you context
    YourContext dbContext = new YourContext();
    String[] firstCategory = dbContext.Categories.Where(x => x.categoryType == "YourFirstCategoryType").ToArray();
    String[] secondCategory = dbContext.Categories.Where(x => x.categoryType == "YourSecondCategoryType").ToArray();
    DataTable dt = new DataTable();
    dt.Columns.Add("Category1");
    dt.Columns.Add("Category2");
    dt.Columns.Add("Total");
    foreach(var c1 in firstCategory)
       foreach(var c2 in firstCategory)
       {
          //create a new row object 
          DataRow R = dt.NewRow();
          
          //set value to the colums
          R[0] = c1;
          R[1] = c2;
          R[2] = GetTotal(c1,c2);//GetTotal is some function that query database and returns total when you have c1 and c2 parameter, you should check is this combination doesn't exist you returns 0
          dt.Rows.Add(R);
       }
