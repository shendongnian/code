    public partial class Form2 : Form
    {
        public delegate bool visibilityToggler();
        public visibilityToggler ToggleVisibility;
            
        public Form2()
        {
            InitializeComponent();
            ToggleVisibility = new visibilityToggler(ToggleLabelVisibility);
        }
        public bool ToggleLabelVisibility()
        {
            label1.Visible = !label1.Visible;
            return label1.Visible;
        }
    }
