    [ControlBuilder(typeof(ValidationBaseBuilder))]
    public abstract class ValidationBase : TextBox, IField { }
    public class ValidationBaseBuilder: ControlBuilder
    {
    	public override void Init(TemplateParser parser, ControlBuilder parentBuilder, Type type, string tagName, string id, System.Collections.IDictionary attribs)
    	{
    		var newType = typeof(/*here you can put a JsRegisterDecorator type*/);
    		base.Init(parser, parentBuilder, t, tagName, id, attribs);
    	}
    }
