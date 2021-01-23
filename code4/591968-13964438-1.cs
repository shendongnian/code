    [ValidationProperty("Text")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Class1 runat=server></{0}:Class1>")]
    public class Class1: CompositeControl
    {
        private TextBox txtbox = new TextBox();
        private RequiredFieldValidator rfv = new RequiredFieldValidator();
        public string Text
        {
            //this will trigger validator inside
            get
            {
                this.rfv.Validate();
                return this.txtbox.Text; //you may need too loop each textbox to check if it's empty and return empty string, if so.
            }
        }
