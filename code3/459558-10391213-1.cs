    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoScroll = true;
            int i = 0;
            Mypanel[] p = new Mypanel[10];
            for (int j = 0; j < 10; j++)
            {
                p[j] = new Mypanel();
                p[j].Location = new Point(0, (i++) * 80);
                this.Controls.Add(p[j]);
            }
        }
    }
    
    public class Mypanel : Panel
    {
        Label label1 = new Label { Text = "first" };
        Label label2 = new Label { Text = "second", Location = new Point(0, 30) };
        public Mypanel()
        {
            this.BackColor = Color.White;
            this.Height = 60;
            this.Controls.Add(label1);
            this.Controls.Add(label2);
        }
    }
