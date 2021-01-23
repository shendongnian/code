        public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            var form = new ChildForm();
            form.Load += form_Load;
            form.Closed += form_Closed;
            base.OnLoad(e);
        }
        void form_Closed(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }
        void form_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.85;
        }
       
    }
