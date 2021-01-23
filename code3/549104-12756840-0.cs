     function DataBound(sender, args) {
                var grid = $find("<%= RadGrid1.ClientID %>");
                if (grid) {
                    var IsColumnHaveData = false;
                    var MasterTable = grid.get_masterTableView();
                    var Rows = MasterTable.get_dataItems();
                    for (var i = 0; i < Rows.length; i++) {
                        var row = Rows[i];
                        
                        if (row.get_dataItem().EmployeeName != null) {
                            IsColumnHaveData = true;
                        }
                        
                    }
                    var Columns = MasterTable.get_columns();
                    for (var i = 0; i < Columns.length; i++) {
                        var column = Columns[i];
                        if (column.get_uniqueName() == "EmployeeName") {
                            column.set_visible(IsColumnHaveData);
                        }
                    }
                }
            }
    <ClientSettings>
                <DataBinding Location="http://localhost/WcfService1/Service1.svc" SelectMethod="GetData"
                    SortParameterType="Linq" FilterParameterType="Linq">
                </DataBinding>
                <ClientEvents OnDataBound="DataBound" />
            </ClientSettings>
