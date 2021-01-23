    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.Office.Interop.Word;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Word;
    
    
    namespace TestApp
    {
        public partial class TestForm : System.Web.UI.Page
        {
    
            protected void Page_Load(object sender, EventArgs e)
            {
            
            }
            public static bool isProtected(object filePath)
            {
                Application myapp = new Application();
    
                object pw = "thispassword";
                try
                {
                    
                    // Trying this for Word document
                    myapp.Documents.Open(ref filePath, PasswordDocument: ref pw); // try open
                    myapp.Documents[ref filePath].Close();  // close it if it does open    
                }
                catch (COMException ex)
                {
                    if (ex.HResult == -2146822880) // Can't Open Doc Caused By Invalid Password
                        return true;
                    else
                        Console.WriteLine(ex.Message + "  " + ex.HResult);  // For debugging, have only tested this one document.
                }
                return false;
            }
        }
    
    }
