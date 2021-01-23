    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                this.NumberOfControls = 0; //very first time when page is loaded, value will be 0
            else
                this.createControls(); //if it is postback it will recreate the controls according to number of control has been created
        }
        
        //this is the base of this, it will hold the number of controls has been created, called properties
        protected int NumberOfControls 
        {
            get { return (int)ViewState["NumControls"]; }
            set { ViewState["NumControls"] = value; }
        }
        //it will create the controls 
        protected void createControls()
        {
            int count = this.NumberOfControls;
            for (int i = 0; i < count; i++) //loop for the total number of control.
            {
                TextBox tx = new TextBox(); //creating new control
                tx.ID = "ControlID_" + i.ToString(); //in your solution you are giving static id, don't do that, assign id number dynamically, it will help you further, if you want to manipulate the controls for some other use
                //Add the Controls to the container of your choice
                form1.Controls.Add(tx);
            }
        }
        //add new control
        protected void addSomeControl()
        {
            TextBox tx = new TextBox();
            tx.ID = "ControlID_" + NumberOfControls.ToString();
            form1.Controls.Add(tx);
            this.NumberOfControls++; //increment the number of control
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            addSomeControl(); 
        }
