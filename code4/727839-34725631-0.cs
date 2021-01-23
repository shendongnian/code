    using System;
    using System.Globalization;
    using System.Web;
    using Antlr4.StringTemplate;
    
    class Program
    {    
    	static void Main(string[] args)
    	{
    		TemplateGroup g = new TemplateGroup('$', '$');
    		g.RegisterRenderer(typeof(string), new HtmlCapableRenderer());
    		string temp = "<html>$var;format=\"html-encode\"$</html>";
    		Template t = new Template(g, temp);
    		t.Add("var", "<>");
    		Console.WriteLine(t.Render());
    		Console.ReadLine();
    	}
    }
    
    public class HtmlCapableRenderer : StringRenderer
    {
    	public override string ToString(object obj, string formatString, CultureInfo culture)
    	{
    		if (obj != null && formatString == "html-encode") {
    			return HttpUtility.HtmlEncode(obj.ToString());
    		} else {
    			return base.ToString(obj, formatString, culture);
    		}
    	}
    }
