        @(Html.Kendo().TreeView().Name("DatabaseTables").DragAndDrop(true)
        .Items(treeview =>
          {
              foreach (var table in Model.TableData)
               {
                var tableName = table.TableName;
                treeview.Add().Text(tableName).Expanded(false).Items(branch=>
                {
                foreach(var field in table.Fields)
                  { 
                    var fieldName = field;
                     branch.Items(fields =>
                     {
                     fields.Add().Text(fieldName);
                     });
               }});}
          }))
 
