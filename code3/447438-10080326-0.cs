    using System;
    using System.IO;
    
    namespace Layouts.Test_control {
    
      public partial class Test_controlSublayout : System.Web.UI.UserControl 
        {
        private void Page_Load(object sender, EventArgs e) {
    
    TextReader tr = new StreamReader("date.txt");
    
    Console.WriteLine(tr.ReadLine());
    
    tr.Close();
        }
      }
    }
