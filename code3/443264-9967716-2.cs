    private void ReloadListViews()
    {
       listView1.DataSource = SomeDbClass.GetItems();
       listView1.DataBind();
    
       listView2.DataSource = SomeDbClass2.GetItems2();
       listView2.DataBind();
      
       // ....
    }
