    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class DesignSurface : UserControl
    {
        public DesignSurface()
        {
            InitializeComponent();            
        }
        private void DesignSurface_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Text = "I love .NET";
        }
    }
