    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Web.Compilation;
    using System.Collections.Generic;
    using System.Resources;
    using System.IO;
    using System.Web.Hosting;
    
    namespace _1423280WebApp
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void BtnLoad_Click(object sender, EventArgs e)
            {
                Page p = BuildManager.CreateInstanceFromVirtualPath(this.TxtPageVirtualPath.Text, typeof(Page)) as Page;
    
                List<String> controlList = new List<String>();
    
                MemoryStream ms = new MemoryStream();
                TextWriter tw = new StreamWriter(ms);
                HtmlTextWriter htw = new HtmlTextWriter(tw);
    
                //this is necessary, Otherwise "Default.aspx" will show the contents of "WebForm1.aspx".
                HttpWorkerRequest hwr = new SimpleWorkerRequest(this.TxtPageVirtualPath.Text, "", tw);
                HttpContext fakeContext = new HttpContext(hwr);
    
                ((IHttpHandler)p).ProcessRequest(fakeContext);
    
                //I could not compile this part in VS2005
                //ResourceManager.AddControls(p.Controls, controlList);
    
    
                this.TxtListControls.Text = "";
                foreach (Control ctr in p.Controls)
                {
                    this.TxtListControls.Text += this.recursiveControls(p, "");
                }
            }
    
            public string recursiveControls(Control control, string ident)
            {
                string retStr = 
                    String.Format(
                        ident + "D='{0}', ClientID='{1}', Type=='{2}' \n",
                        control.ID,
                        control.ClientID,
                        control.GetType().FullName);
                foreach (Control innerCtr in control.Controls)
                {
                    retStr += this.recursiveControls(innerCtr, " " + ident);
                }
    
                return retStr;
            }
        }
    }
