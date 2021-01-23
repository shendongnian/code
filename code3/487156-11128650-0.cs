    public class CMyDataClass {
       public bool CompareText(System.Web.UI.Page i_oPage) {
          TextBox oTextBox = i_oPage.FindControl("TextBox1");
          return (oTextBox.Text == "My Data");
       }
    }
