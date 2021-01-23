    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Text.RegularExpressions;
    
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            private Dictionary<string, bool> rules = null;
            public Dictionary<string, bool> Rules
            {
                get
                {
                    if (rules == null)
                    {
                        // 1. use [0-9]{1,3} instead of x to represent any 1-3 digit numeric value
                        // 2. escape dots like such \. 
                        rules = new Dictionary<string, bool>();
                        rules.Add(@"192\.168\.2\.10", true);
                        rules.Add(@"192\.168\.3\.[0-9]{1,3}", true);
                        rules.Add(@"10\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}", false);
                    }
                    return rules;
                }
            }
    
            protected bool IsAuthorizedByIP()
            {
                bool isAuthorized = false;
    
                // get current IP
                string currentIP = Request.ServerVariables["REMOTE_ADDR"];
                currentIP = "10.168.2.10";
    
                // set Authorization flag by evaluating rules
                foreach (var rule in Rules)
                {
                    if (Regex.IsMatch(currentIP, rule.Key))
                        isAuthorized = rule.Value;
                }
    
                return isAuthorized;
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsAuthorizedByIP())
                {
                    // do something that applies to authorized IPs
                    Response.Write("You are authorized!");
                }
            }
        }
    }
