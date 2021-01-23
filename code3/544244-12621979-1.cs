    @using System.Dynamic
    <div>
    @{
       var result = new List<dynamic>();
       foreach (var emprow in Model.DDS)
       {
           var row = (IDictionary<string, object>)new ExpandoObject();
           Dictionary<string, object> eachEmpRow = (Dictionary<string, object>)emprow;
           foreach (KeyValuePair<string, object> keyValuePair in eachEmpRow)
           {
               row.Add(keyValuePair);
           }
           result.Add(row);
       }
       var grid = new WebGrid(result);
       
     }
     @grid.GetHtml(
	       tableStyle: "grid",
           headerStyle: "grid-header",
           alternatingRowStyle: "grid-alternating-row",
           selectedRowStyle: "grid-selected-row",
           rowStyle: "grid-row-style"
           )
     </div>
