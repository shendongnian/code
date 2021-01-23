    public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //IsPostBack false when page loads first time
                if (!IsPostBack)  //same as $_POST['Submit'] in PHP
                {
                    //use this if block to initialize your controls values
                    yourTextBox.Text = "Please enter value";
                }
            }
    
            protected void yourButton_Click(object sender, EventArgs e)
            {
                //obtain control values
                //do form prcessing
                string userInput = yourTextBox.Text;
                //write your business logic here, 
            
                //redirect to next page
                Response.Redirect("action.aspx");
            }
        }
