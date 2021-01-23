    List<string> columns = new List<string>{"Column2","Column1","Column5","Column3","Column6","Column4"};
    var dic = columns.Select((x,i)=>new {x,i})
                     .OrderBy(a=>a.x).ToList();
    for(int i = 0; i < dic.Count; i++)
       dataTable.Columns[dic[i].x].SetOrdinal(dic[i].i);
