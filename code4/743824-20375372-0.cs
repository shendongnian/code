    public class HtmlAttributeEncodingNot : System.Web.Util.HttpEncoder
    {
        protected override void HtmlAttributeEncode(string value, System.IO.TextWriter output)
        {
            output.Write(value);
        }
    }
