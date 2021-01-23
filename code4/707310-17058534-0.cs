    private class RemoveNamesHtmlTextWriter : HtmlTextWriter
    {    
        public override void WriteAttribute(string name, string value, bool fEncode) 
        { 
            if (name.Equals("name", StringComparison.OrdinalIgnoreCase)) return;
                return; 
        
            base.WriteAttribute(name, value, fEncode); 
        }
    }
    protected override void Render(HtmlTextWriter writer)
    {
        var RemoveNamesWriter = new RemoveNamesHtmlTextWriter(writer);
        base.Render(RemoveNamesWriter);
    }
