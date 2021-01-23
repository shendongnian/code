    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }
        protected override OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var menu = new CustomMenu();
                menu.Location = PointToScreen(e.Location);
                menu.Show(this);                
            }
        }
    }
