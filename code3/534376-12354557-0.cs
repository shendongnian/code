    if(!page.IsPostBack) // This goes into Page_Load
    {
    Panel1.Visible=false;
    }
    
    protected void adddelegate_Click(object sender, EventArgs e)   // add this additional code
    {
    Panel.Visible=True;
    GetDelegate()// This method retrieve the delegate you inserted..
    Lable1.Text= "Set here Delegate name you just Retrieved"
    Label2.Text="Delegate time you retrived"
    }
    
    protected void BtnRemovedelegate_Click(object sender, EventArgs e)
    
    {
    string Personidd= retrieve person id
    string delegateName= Lable1.text;
    String timeslot=Label2.Text
    SomeDeleteMethod(personidd, delegateName, timeslot); 
    Panel1.Visible=false;
    }
