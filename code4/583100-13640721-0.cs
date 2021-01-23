    using System;
    using Gtk;
    using System.Threading;
    
    public partial class MainWindow: Gtk.Window
    {   
    	public MainWindow (): base (Gtk.WindowType.Toplevel)
    	{
    		Build ();
    	}
    	
    	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    	{
    		Application.Quit ();
    		a.RetVal = true;
    	}
    	
    	protected void OnOkClicked (object sender, EventArgs e)
    	{
    		Thread thr = new Thread (new ThreadStart (ThreadRoutine));
    		thr.Start ();
    	}
    
    	void ThreadRoutine ()
    	{
    		for (int i = 0; i < 100; i++)
    		{
    			LargeComputation ();
    			Application.Invoke (delegate {
    				progressbar1.Fraction = i / 100.0;
    			});
    		}
    	}
    	
    	void LargeComputation ()
    	{
    		// lots of processing here
    		Thread.Sleep(1000);
    	}
    }
