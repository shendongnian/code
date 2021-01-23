    public class main
    {
       protected void Page_Load(object sender, EventArgs e)
       {
          //stores value into session
          ExampleSession.UserName = "foo";
          ExampleSession.ProductsSelected.Add("bar"); 
          txtInput.Text = ExampleSession.UserName; //retrieves value from session
       }
    }
