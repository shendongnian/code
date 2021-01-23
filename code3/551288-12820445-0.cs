    namespace WebApplication1
    {
        using System;
        public partial class _Default : System.Web.UI.Page
        { 
            public Client Clients { get; set; }
            protected void Page_Load(object sender, EventArgs e)
            {
                Client objClients = populate();
                if (objClients != null)
                {
                    Clients = objClients;
                }
            }
            private Client populate()
            {
                return new Client() { Address1 =  "Somewhere in London" };
            }
        }
        public class Client
        {
            public string Address1 { get; set; }
        }
    }
