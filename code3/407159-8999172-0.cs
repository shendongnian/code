    foreach(String name in Privilige_NameList){
        TableRow tr = new TableRow();
        TableCell tcTitle = new TableCell();
        tc1.Value = name;
        tr.Add(tc1);
        foreach(String checkboxTitle in view_nameList){
            TableCell tc = new TableCell();
            CheckBox cb = new CheckBox();
            cb.Text = checkBoxTitle;
            tc.Add(cb);
            tr.Add(tc);
        }            
    }
