    private void Page_Load()
    {
        if (!Page.IsPostBack)
        {
            //when the pages is rendered and loaded for the first time execution goes here
            //so... call the method that selects the first row
            SelectsFirtsRow();
        }
        else
        {
         //do something else
         ...
        }
    }
    protected void FirstRowLinkButton_Click(object sender, EventArgs e)
    {
        //move all the code that selects the first row to a method.
        //you can also supply some arguments if they are needed for method execution... that's up to you
        SelectsFirtsRow();
    }
    public void SelectsFirtsRow();
    {
        //your logic goes here. i.e. selects the first row
    }
