    var items = (from r in dtItems.AsEnumerable()
            let index = dtItems.Rows.IndexOf(r)
            where (string)r["emp_num"].Equals(txt_EmpNum.Text.Trim())
            select new{index=index,row=r}).ToList();
    var firstHour = 5 + 1 - items.Count; // this is what you need
    foreach(var item in items){
        if (item.index == 0)
        {
            item.row["hours"] = firstHour;  
        }
        else {
            item.row["hours"] = 1;
        }
    }
    var dtEmp = items.Select(i => i.row).CopyToDataTable();
