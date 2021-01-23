    Initialize(){
        DataGridView view = new DataGridView();
        view.BindingSource = bs;
        bs.dataSource = dataTable;
        //Fill Data Table using Adapter.
        da.fill(dataTable);
    }
    CallMeEveryFewMinutes(DataTable dataTable){
        List<String> changed = findChangedOjbects();
        // Fill datatable2 with changed objects.
        da2.fill(datatable2, changed)     
        Refresh(dataTable, datatable2);
        // dataTable is now refreshed. Bind it again so changes are reflected.
        // ********** PROBLEM AREA -- SOLVED ***************
        // once in a while it throws the below exception.
        //bs.dataSource = dataTable; don't rebind the same datatable, but rather reset the bindings.
        bs.ResetBindings(false);
    } 
