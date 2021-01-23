    using System;
    using System.Globalization;
    using System.Security;
    using System.Text;
    using System.Web;
    using Antlr4.StringTemplate;
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		TemplateGroup g = new TemplateGroup('$', '$');
    		g.RegisterRenderer(typeof(object), new MyTemplateRenderer());
    		string temp = "<html>$var;format=\"html-encode\"$</html>\n$date;format=\"{0:R}\"$";
    		Template t = new Template(g, temp);
    		t.Add("var", "<>");
    		t.Add("date", DateTime.Now);
    		Console.WriteLine(t.Render());
    		Console.ReadLine();
    	}
    }
    
    public class MyTemplateRenderer : IAttributeRenderer
    {
    	public virtual string ToString(object o, string formatString, CultureInfo culture)
    	{
    		if (formatString == null) return o.ToString();
    
    		switch (formatString) {
    			case "upper":
    				return o.ToString().ToUpper(culture);
    			case "lower":
    				return o.ToString().ToLower(culture);
    			case "cap":
    				string s = o.ToString();
    				return s.Length > 0 ? Char.ToUpper(s[0], culture) + s.Substring(1) : s;
    			case "url-encode":
    				return HttpUtility.UrlEncode(o.ToString(), Encoding.UTF8);
    			case "xml-encode":
    				return SecurityElement.Escape(o.ToString());
    			case "html-encode":
    				return HttpUtility.HtmlEncode(o);
    			default:
    				return String.Format(culture, formatString, o);
    		}
    	}
    }
