    var duplicates = suppliers_arr
        .GroupBy(i => i)
        .Where(g => g.Count() > 1)
        .Select(g => g.Key); 
    if(duplicates.Count() > 0){
        foreach (var d in duplicates)
        {
            ModelState.AddFormError(string.Format("{0} is duplicated",d.ToString()));
        }
    }else{
         //no duplicates
    }
