        @(Html.Kendo().TreeView().Name("DatabaseTables").DragAndDrop(true)
        .Items(treeview =>
          {
              foreach (var table in Model.TableData)
               {
                foreach(var field in table.Fields)
                  { var tableName = table.TableName;
                    var fieldName = field;
                     treeview.Add().Text(tableName).Expanded(false).Items(fields =>
              {
                  fields.Add().Text(fieldName);
              });}}
          }))
 
