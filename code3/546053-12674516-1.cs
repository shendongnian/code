    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Show();
            label1.Text="Initializing Form1";
            Form1 dlg=new Form1();
            dlg.Show();
            Application.DoEvents();
            dlg.Location=new Point(this.Location.X+this.Size.Width+5, this.Location.Y);
            System.Threading.Thread.Sleep(1400);
            
            for(int i=0; i<10; i++)
            {
                label1.Text="Setting Progress Bar at "+(i+1).ToString()+" of 10";
                dlg.SetProgress(i+1, 10);
                Application.DoEvents();
                System.Threading.Thread.Sleep(1400);
            }
            label1.Text="Done!";
        }
    }
