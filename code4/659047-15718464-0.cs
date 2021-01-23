	TextBox txt = Util.ApplySettings(o =>
	{
		o.Caption = "Name";
		o.FieldName = "UserName";
		o.Width = 20;
		o.Name = "txtName";
	});
    public class Util
    {
        public static TextBox ApplySettings(TextBoxConfig config)
        {
            //Doing something
        }
        public static TextBox ApplySettings(Action<TextBoxConfig> modifier)
        {
            var config = new TextBoxConfig();
            modifier(config);
            return ApplySettings(config);            
        }
    }
