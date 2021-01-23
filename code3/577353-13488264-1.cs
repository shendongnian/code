    private void BindListView()
    {
        //get the current textbox count     int count = 1;
        if (ViewState["textboxCount"] != null)
            count = (int)ViewState["textboxCount"];
    
        //create an enumerable range based on the current count     IEnumerable<int> enumerable = Enumerable.Range(1, count);
    
        //bind the listview     this.lvDynamicTextboxes.DataSource = enumerable;
        this.lvDynamicTextboxes.DataBind();
    }
    
    private void IncrementTextboxCount()
    {
        int count = 1;
        if (ViewState["textboxCount"] != null)
            count = (int)ViewState["textboxCount"];
    
        count++;
        ViewState["textboxCount"] = count;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
       {
            this.BindListView();  
        }
    }
    
    protected void btnAddTextBox_Click(object sender, EventArgs e)
    {
        this.IncrementTextboxCount();
        this.BindListView();
    }
