    public void OnConnection(object application, 
        ext_ConnectMode connectMode, 
        object addInInst, ref Array custom)
    {
        MessageBox.Show("message box");
        // or you could use your on dialog class
        var myDialog=new MyDialog();
        myDialog.Show();
        // ...
    }
