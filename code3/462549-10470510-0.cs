    namespace WebApplication4 
    { 
      public partial class WebForm17 : System.Web.UI.Page 
      { 
         DATAACCESS aaa = new DATAACCESS(); 
         string  Dname = "Finding"; 
 
         protected void Page_Load(object sender, EventArgs e) 
         {  
              aaa = new DATAACCESS(); 
              if(!IsPostBack)
              {
                  TextBox2.Text= aaa.GetDoctext(Dname, 90); 
              }
         } 
 
         protected void Button5_Click(object sender, EventArgs e) 
         { 
 
             string textboxvalue = TextBox2.Text;
             aaa.savetext(textboxvalue, Dname, 90); 
         } 
      } 
    } 
