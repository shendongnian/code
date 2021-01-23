    protected override void RenderContents(HtmlTextWriter output)
            {
                
                output.Write("<div><div class=\"UserSectionHead\">");
    
                Label l = new Label() { Text = Label };
                TextBox t = new TextBox() { Text = Text };
                l.AssociatedControlID = t.ID;
                l.RenderControl(output);
    
                output.Write("</div><div class=\"UserSectionBody\"><div class=\"UserControlGroup\"><nobr>");
    
                t.RenderControl(output);
    
                output.Write("</nobr></div></div><div style=\"width:100%\" class=\"UserDottedLine\"></div>");
    
            }
