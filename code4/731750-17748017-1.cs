    namespace StackOverflow.WinForms
    {
        using System.Windows.Forms;
        public partial class Form1 : Form
        {
            private TimeCalculate timeCalculate;
            public Form1()
            {
                InitializeComponent();
                this.timeCalculate = new TimeCalculate();
                this.timeCalculate.TheTimeChanged += new TimeCalculate.TimerTickHandler(TimeHasChanged);
            }
            protected void TimeHasChanged(string newTime)
            {
                this.txtTheTime.Text = newTime;
            }
        }
    }
