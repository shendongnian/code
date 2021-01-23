    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    using Timer = System.Threading.Timer;
    
    public class Program
    {
    	static void Main(string[] args)
        {
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		Application.Run(new TestForm());
        }
    }
    
    class TestForm : Form
    {
    	protected override void OnLoad(EventArgs e)
    	{
    		base.OnLoad(e);
            var timer = new Timer(TimerProc, null, 1000, 1000);
    	}
    
        public void TimerProc(object state)
        {
            for (int i = 0; i <= 6; i++)
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }
    }
