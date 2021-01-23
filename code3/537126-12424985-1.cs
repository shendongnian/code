    namespace WebApplication1
    {
       using System;
       public partial class _Default : System.Web.UI.Page
       {
           protected void Page_Load(object sender, EventArgs e)
           {
           }
           protected void MyBtn_Clicked(object sender, EventArgs args)
           {
               this.MyLabel.Text = this.MyTextBox.Text;
           }
       }
    }
