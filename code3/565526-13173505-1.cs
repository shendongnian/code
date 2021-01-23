    if (lblprices.Text != "")
    {
        arrprice = lblprices.Text.Split(new char[] { ';' }, 
                                        StringSplitOptions.RemoveEmptyEntries);
        var lst = arrprice.ToList();
        lst.Sort((x, y) => int.Parse(x.Split(',')[0]).CompareTo(int.Parse(y.Split(',')[0])));
        
       for (i = 0; i < lst.Count; i++)
       {
           arr2 = lst[i].Split(',');
           //rest of your code ----------------
       }
