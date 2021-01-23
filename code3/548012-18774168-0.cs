    List<string> myControls = new List<string>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
         if(!IsPostBack)
         {
              myControls = new List<string>();
              ViewState["myControls"] = myControls;
         }
    }
    
    protected void override void LoadViewState(object savedState)
    {
         base.LoadViewState(savedState);
         myControls = (List<string>)ViewState["myControls"];
    
         foreach(string controlID in myControls){
              //method to create your buttons goes here.
              createButtons(controlID);
         }
    }
    
    public void createButtons(string btnID){
         Button btn = new Button();
         btn.ID = btnID;
         btn.Text = "Add New";
         btn.Click += new RoutedEventHandler(this.GreetingBtn_Click);
         Panel1.Controls.Add(btn);
         Panel1.Controls.Add(new LiteralControl("<br /><br />"));
    }
    
    void GreetingBtn_Click(Object sender, RoutedEventArgs e){
         create();
    }
    
