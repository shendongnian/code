    <radgrid...>
    <masterTableView ... >
       <columns>
          <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn">
               <HeaderStyle Width="35px" />
           </telerik:GridClientSelectColumn>
        </columns>
    </MasterTableView>
     <ClientSettings>
           <ClientEvents OnRowSelected="RowSelected" OnRowDeselected="RowDeselected"/>
     </ClientSettings>
    </radgrid>
           function RowDeselected(sender, eventArgs){
                //your code
            }
            function RowSelected(sender,eventArgs)
            {
                var MasterTable = sender.get_masterTableView();
                var selectedRows = MasterTable.get_selectedItems();
                var selectedRowsCount = selectedRows.length;
                //etc
            }
