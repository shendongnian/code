    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            toolStrip1.Renderer = new MyRenderer();
        }
        private class MyRenderer : ToolStripProfessionalRenderer {
            public MyRenderer() : base(new MyColors()) {}
        }
        private class MyColors : ProfessionalColorTable {
            public override Color ButtonSelectedGradientBegin {
                get { return Color.Black; }
            }
            public override Color ButtonSelectedGradientMiddle {
                get { return Color.Black; }
            }
            public override Color ButtonSelectedGradientEnd {
                get { return Color.Black; }
            }
        }
    }
