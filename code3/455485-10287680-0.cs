    public partial class Main : System.Web.UI.Page
    {
            
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                     Session["MyList"] = new List<string>();
                }   
                ComboBox cbo = myComboBox; //this is the combobox in your page
                cbo.DataSource = (List<string>)Session["MyList"];
                cbo.DataBind();
            }
            
           
        
        
            protected void cmdAdd_Click(object sender, EventArgs e)
            {
                List<string> code = Session["MyList"];
                code.Add(lstCode.Text);
                Session["MyList"] = code;  
                myComboBox.DataSource = code;
                myComboBox.DataBind();
            }
        }
