    // In your page load
    if (!Page.IsPostBack())
    {
       BindData();   // This calls the binding method the first time you hit the page.
    }
    
    // In your button click event
    if (Page.IsValid())
    {
       UpdateData();
       BindData();   // If you don't call this method, you'll post back, but not rebind.
    }
    
    // In your BindData method
    txtThis.Text = data.this;
    txtThat.Text = data.that;
