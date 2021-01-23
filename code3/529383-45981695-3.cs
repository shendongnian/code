	public partial class Form1 : Form 
	{ 
	
		public Form1() 
		{ 
			InitializeComponent(); 
		}
		BGimplent obj = null;
		private void button1_Click(object sender, EventArgs e)
		{
			int i = 0;
			 obj = new BGimplent();
			obj.eveBG += obj_eveBG;
			i = 5;
			obj.MyProperty = 5;
			obj.DoConfig();
			obj.ManualReset.WaitOne();
			obj.MyProperty = 10;
			obj.MyProperty = 11;
			obj.MyProperty = 12;
			obj.MyProperty = 13;
			obj.MyProperty = 14;
		}
		void obj_eveBG(string s)
		{
			obj.ManualReset.Set();
			MessageBox.Show(s);
		}
	}
	/*
	*******************************************************
		Paste below code in adding new class i.e. Class1
		
		
	*/
	public delegate void delBG(string s);
	class BGimplent
	{
		public event  delBG eveBG;
		private ManualResetEvent mnuReset = new ManualResetEvent(false);
		public ManualResetEvent ManualReset { get; set; }
		public int MyProperty { get; set; }
		BackgroundWorker bgWorker = new BackgroundWorker();
		public void DoConfig()
		{
			ManualReset = mnuReset;
			bgWorker.DoWork += bgWorker_DoWork;
			bgWorker.ProgressChanged += bgWorker_ProgressChanged;
			bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
			bgWorker.RunWorkerAsync();            
		}
		
		void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{   
			Thread.Sleep(5000);
			if (eveBG != null)
				eveBG("Value of MyProperty: " + MyProperty.ToString());
		}
	}
