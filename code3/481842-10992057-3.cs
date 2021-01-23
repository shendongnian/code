    lst.AddRange(firstList.Select(item => new ListDataSourceViewModel 
         {
             Text = item, IsFromFirstList = true
         }
    ).ToArray());
    lst.AddRange(secondList.Select(item => new ListDataSourceViewModel 
    {
         Text = item, IsFromFirstList = false
    }
    ).ToArray());
