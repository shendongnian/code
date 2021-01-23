    public class RewriteFormHtmlTextWriter : HtmlTextWriter
    {
        public RewriteFormHtmlTextWriter(HtmlTextWriter writer)
            : base(writer)
        {
            this.InnerWriter = writer.InnerWriter;
        }
        public RewriteFormHtmlTextWriter(System.IO.TextWriter writer)
            : base(writer)
        {
            base.InnerWriter = writer;
        }
    
        public override void WriteAttribute(string name, string value, bool fEncode)
        {
    		if (name == "action")
    		{
    			value = "Change here your value"			
    		}
    
            base.WriteAttribute(name, value, fEncode);
        }
    }
