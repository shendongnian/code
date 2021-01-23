    private List<myObject> _data = null;
    private void Page_Load(object sender, System.EventArgs e)
    {
        if(!Page.IsPostBack)                        
        {
            _data = loadDataFromDb();
        }
    }
    private void Button_Click()
    {
        if(_data != null)
           //Do something with the data
    }
