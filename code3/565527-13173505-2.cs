    if (lblprices.Text != "")
    {
        arrprice = lblprices.Text.Split(new char[] { ';' }, 
                                        StringSplitOptions.RemoveEmptyEntries);
        var lst = arrprice.OrderBy(x => int.Parse(x.Split(',')[0])).ToList();
        
        for (i = 0; i < lst.Count; i++)
        {
            arr2 = lst[i].Split(',');
            //rest of your code ----------------
        }
