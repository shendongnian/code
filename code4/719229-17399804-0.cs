    public partial class Main : System.Web.UI.Page
    {
        public String TicketNum
        {
            get { return textbox.Text; }
            set { textbox.Text = value; }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Class1 selectTop1 = new Class1();
            TicketNum = selectTop1.SelectTop1();
        }
    }
    public class Class1
    {
        public string SelectTop1()
        {
            // assign the value from SQL to the response variable
            string response = "test";
            return response;
        }
    }
