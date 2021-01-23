    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.Web;
    namespace WebClientPostForm
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                PostToServer();
            }
            public void PostToServer()
            {
                TxtOutput.Text += "Initialising... ";
	    		
                // string is formatted like this for readability
                string code = "int main()" +
				"{" +
				    "printf(\"Hello World!\");" +
				"}";
			
                // the code is URL-encoded so that characters are escaped
                string data = string.Format("code={0}&lang=c&submit=Execute", HttpUtility.UrlEncode(code));
   
                WebClient client = new WebClient();
                // I couldn't get this to work unless I set the content type
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
			
                client.UploadStringCompleted += (sender, e) => 
                    {
                        TxtOutput.Text += string.Format("Request complete. Response: {0}", e.Result);
                    };
                TxtOutput.Text += "Posting Data To Server... ";
                client.UploadStringAsync(new Uri("http://www.compileonline.com/compile.php"), data);
            }
        }
    }
