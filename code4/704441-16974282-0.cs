    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO.Ports;
    using TCCWindows.Lib;
    using System.Web.Http.SelfHost;
    using System.Web.Http;
    
    
    namespace TCCWindows
    {
        public partial class FormPrincipal : Form
        {   
            HttpSelfHostServer server;
            HttpSelfHostConfiguration config;
    
            public FormPrincipal()
            {
                InitializeComponent();
            }
    
            private void button2_Click_2(object sender, EventArgs e)
            {
                config = new HttpSelfHostConfiguration(textBox1.Text);
    
                config.Routes.MapHttpRoute(
                    "API Default", "api/{controller}/{id}",
                    new { id = RouteParameter.Optional });
                server = new HttpSelfHostServer(config);
                server.OpenAsync();              
                MessageBox.Show("Server is ready!");  
            }
    
            private void button3_Click_1(object sender, EventArgs e)
            {
                server.CloseAsync();    
            }
        }
    
        public class ProductsController : ApiController
        {
    
            public string GetProductsByCategory(string category)
            {
                return (category ?? "Vazio");
            }
        }
    }
