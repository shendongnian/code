    List<IndexData> list = new List<IndexData>()
    {
        new IndexData(){ColumnName="column1",Data="data1"},
        new IndexData(){ColumnName="column2",Data="data2"},
    };
    //Using Json.Net
    var json1 = JsonConvert.SerializeObject(
                    new {IndexData=list.ToDictionary(x => x.ColumnName, x => x.Data)});
    //Using JavaScriptSerializer
    var json2 = new JavaScriptSerializer().Serialize(
                    new { IndexData = list.ToDictionary(x => x.ColumnName, x => x.Data) });
