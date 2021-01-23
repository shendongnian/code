    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
            mdiClient = Controls[0] as MdiClient;
            if (mdiClient != null) {
                mdiClient.Paint += OnMdiClientPaint;
            }
        }
        private MdiClient mdiClient;
        private void OnMdiClientPaint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.Blue, mdiClient.ClientRectangle);
        }
    }
