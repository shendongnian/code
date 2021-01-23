    private void Page_Load()
    {
        if (!IsPostBack)
        {
    
           string strUrlFormat = Request.ServerVariables["SCRIPT_NAME"] + "?LC={0:d}&DD=true"
           // get the gridview object and set the DataNavigateUrlFormatString property for the column in question here...  so if you gridview ID = "myGridView" and it is the third column...
           myGridView.Columns[2].DataNavigateUrlFormatString = strUtlFormat;
    
        }
    }
