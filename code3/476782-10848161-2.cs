    private void Page_Load()
    {
        if (!IsPostBack)
        {
            // load only fist time 
            LaodCheckBoxList();
        }
    }
