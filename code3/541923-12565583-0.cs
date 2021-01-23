    protected void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ci=null;
			System.GC.RunFinalizers();
			Application.ExitThread();
			Application.Exit();
		}
