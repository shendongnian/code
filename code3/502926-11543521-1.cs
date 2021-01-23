                private String _ClientInstanceName;
                /// <summary>
                /// Gets or Sets the client instance name.
                /// </summary>
                [
                Bindable(true), Category("Client-Side"),
                DefaultValue(""), Description("The ClientInstanceName can be used to reference this control on the client.")
                ]
                public String ClientInstanceName
                {
                    get
                    {
                        return _ClientInstanceName;
                    }
                    set
                    {
                        _ClientInstanceName= value;
                    }
                }
    
    
            protected override void OnPreRender(EventArgs e)
            {
                base.OnPreRender(e);
    
                //Register startup script for creating JavaScript reference to this server control object.
                if (this.ClientInstanceName.Length > 0) { registerClientInstanceName(this.ClientInstanceName, this.ClientID); }
            }
    
            /// <summary>
            /// Create a JavaScript reference to the Object with ClientID using the ClientInstanceName property.
            /// Based on: http://msdn.microsoft.com/en-us/library/asz8zsxy.aspx
            /// </summary>
            /// <param name="ClientInstanceName"></param>
            private void registerClientInstanceName(String ClientInstanceName, String ClientID)
            {
                // Define the name and type of the client scripts on the page.
                String csname1 = "ClientInstanceNameScript";
                Type cstype = this.GetType();
    
                // Get a ClientScriptManager reference from the Page class.
                ClientScriptManager cs = Page.ClientScript;
    
                // Check to see if the startup script is already registered.
                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    StringBuilder cstext1 = new StringBuilder();
                    cstext1.Append("<script type=text/javascript>");
                    cstext1.Append("window['" + ClientInstanceName + "']=document.getElementById('" + ClientID + "');");
                    cstext1.Append("</script>");
    
                    cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
                }
            }
