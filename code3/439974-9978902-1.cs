    public class ServerControl1 : Panel, IScriptControl
        {           
            private RadAsyncUpload AsyncUpload;
         
            public ServerControl1()
            {
                ID = Guid.NewGuid().ToString();
                AsyncUpload = new RadAsyncUpload();
            }
            protected override void OnInit(EventArgs e)
            {
                Page.ClientScript.RegisterClientScriptResource(GetType(), "ImageControl.jquery.min.js");                
                Controls.Add(AsyncUpload);
                base.OnInit(e);
            }
            protected override void OnPreRender(EventArgs e)
            {
                var manager = ScriptManager.GetCurrent(Page);
                if (manager == null)
                {
                    throw new InvalidOperationException("A ScriptManager is required on the page.");
                }
                manager.RegisterScriptControl(this);
                base.OnPreRender(e);
            }
            protected override void Render(HtmlTextWriter writer)
            {
                if (!DesignMode)
                    ScriptManager.GetCurrent(Page).RegisterScriptDescriptors(this);
                base.Render(writer);
            }    
            public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
            {
                var descriptor = new ScriptControlDescriptor("ImageControl.ClientControl1", this.ClientID);
                descriptor.AddProperty("AsyncUpload", this.AsyncUpload.ClientID);
                yield return descriptor;
            }    
            public IEnumerable<ScriptReference> GetScriptReferences()
            {
                yield return new ScriptReference("ImageControl.ClientControl1.js", GetType().Assembly.FullName);
            }
        }
