    public partial class OptionsWindow : Form
    {
        public Options { get; set; }
        public bool AllowToolTip
        {
            get { return Options.AllowToolTips; }
            set { Options.AllowToolTips = value; }
        }
    }
