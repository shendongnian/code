    public partial class Form1 : Form
    {
       Form2 _form2 = new Form2("");
       Timer _timer;
       int _counter;
       public Form1()
       {
           InitializeComponent();          
           _form2.Show();
           if (components == null)
               components = new System.ComponentModel.Container();
           _timer = new Timer(components); // required for correct disposing
           _timer.Interval = 500;
           _timer.Tick += timer_Tick;
           _timer.Start();
       }
       private void timer_Tick(object sender, EventArgs e)
       {
           if (_counter < 5)
           {
              _form2.label1.Text = _counter.ToString();
              _counter++;
              return;
           }
           _timer.Stop();
       }
