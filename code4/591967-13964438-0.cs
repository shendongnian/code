    [ValidationProperty("Text")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Class1 runat=server></{0}:Class1>")]
    public class Class1: CompositeControl
    {
        private TextBox txtbox = new TextBox();
        public string Text
        {
            get
            {
                return this.txtbox.Text;
            }
        }
