    public partial class Form1 : Form
    {
       Form2 _form2 = new Form2("");
       Timer _timer = new Timer();
       int _counter;
       public Form1()
       {
           InitializeComponent();
           _form2.Show();
           _timer.Interval = 500;
           _timer.Tick += timer_Tick;
           _timer.Start();
       }
       private void timer_Tick(object sender, EventArgs e)
       {
           _form2.label1.Text = _counter.ToString();
           _counter++;
       }
