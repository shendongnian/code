    public partial class Form1 : Form
    {
        int facebookInterval = 5; //5 sec
        int twitterInterval = 7; //7 sec
        public Form1()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 1000; //1 sec
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
        void t_Tick(object sender, EventArgs e)
        {
            facebookInterval--;
            twitterInterval--;
            if (facebookInterval == 0)
            {
                MessageBox.Show("Getting FB data");
                facebookInterval = 5; //reset to base value
            }
            if (twitterInterval == 0)
            {
                MessageBox.Show("Getting Twitter data");
                twitterInterval = 7; //reset to base value
            }
        }
    }
