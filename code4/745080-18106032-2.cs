    List<int> indices = new List<int>{1,2,0,7,4,5,3,6};
    var dic = indices.Select((x,i)=>new {x,i})
                     .OrderBy(a=>a.x).ToList();
    for(int i = 0; i < dic.Count(); i++){
        dataTable.Columns[dic[i].x].SetOrdinal(dic[i].i);
    }
