    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            label1.AutoSize = false;
            label1.Size = new Size(100, 60);
            label1.Text = "Autosize this";
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.Resize += new EventHandler(label1_Resize);
        }
        void label1_Resize(object sender, EventArgs e) {
            using (var gr = label1.CreateGraphics()) {
                Font font = label1.Font;
                for (int size = (int)(label1.Height * 72 / gr.DpiY); size >= 8; --size) {
                    font = new Font(label1.Font.FontFamily, size, label1.Font.Style);
                    if (TextRenderer.MeasureText(label1.Text, font).Width <= label1.ClientSize.Width) break;
                }
                label1.Font = font;
            }
        }
        protected override void OnLoad(EventArgs e) {
            label1_Resize(this, EventArgs.Empty);
            base.OnLoad(e);
        }
    }
