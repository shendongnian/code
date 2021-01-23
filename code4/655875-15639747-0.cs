    public partial class MyUserControl : System.Web.UI.UserControl
    {
        private Dictionary<string, string> labels = new Dictionary<string, string>();
        public LabelParam Param
        {
            private get { return null; }
            set
            { 
                labels.Add(value.Key, value.Value); 
            }
        }
        public class LabelParam : WebControl
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public LabelParam() { }
            public LabelParam(string key, string value) { Key = key; Value = value; }
        }
    }
