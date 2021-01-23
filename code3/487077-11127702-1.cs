    public partial class Default : System.Web.UI.Page
        {
            private List<string> values = new List<string>();
    
            protected void Page_Load(object sender, EventArgs e)
            {
                
            }        
    
            protected override object SaveViewState()
            {
                object baseState = base.SaveViewState();            
                object[] allStates = new object[2];
                allStates[0] = baseState;
                allStates[1] = values;
                return allStates;
            }
    
            protected override void LoadViewState(object savedState)
            {
                object[] myState = (object[])savedState;
                if (myState[0] != null)
                    base.LoadViewState(myState[0]);
                if (myState[1] != null)
                {
                    values = (List<string>)myState[1];
                    MyRender();
                }
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < 10; i++)
                {
                    DropDownList ddl = new DropDownList();
                    ddl.ID = "ClientID" + i;
                    
                    ddl.Items.Add("Item 1");
                    ddl.Items.Add("Item 2");
                    ddl.AutoPostBack = true;                
                    values.Add(ddl.SelectedValue);
    
                    myDiv.Controls.Add(ddl);
                }
            }
    
            private void MyRender()
            {
                for (int i = 0; i < values.Count; i++)
                {
                    DropDownList ddl = new DropDownList();
                    ddl.ID = "ClientID" + i;
                    
                    ddl.Items.Add("Item 1");
                    ddl.Items.Add("Item 2");
                    ddl.AutoPostBack = true;
                    ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
                    
                    myDiv.Controls.Add(ddl);
                }
            }
    
            void ddl_SelectedIndexChanged(object sender, EventArgs e)
            {
                lblDescription.Text = ((DropDownList)sender).ID + ": Selected Index Changed";
            }
        }
