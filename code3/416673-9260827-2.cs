    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
        }
        private class MyRenderer : ToolStripProfessionalRenderer {
            public MyRenderer() : base(new MyColors()) {}
        }
        private class MyColors : ProfessionalColorTable {
            public override Color MenuItemSelected {
                get { return Color.Yellow; }
            }
            public override Color MenuItemSelectedGradientBegin {
                get { return Color.Orange; }
            }
            public override Color MenuItemSelectedGradientEnd {
                get { return Color.Yellow; }
            }
        }
    }
