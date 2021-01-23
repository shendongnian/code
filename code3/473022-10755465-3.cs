    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Timers;
    using System.Text;
    namespace SampleWinSvc
    {
    	public partial class Service1 : ServiceBase
    	{
    		/// <summary>
    		/// This timer willl run the process at the interval specified (currently 10 seconds) once enabled
    		/// </summary>
    		Timer timer = new Timer(10000);
    
    		public Service1()
    		{
    			InitializeComponent();
    		}
    
    		protected override void OnStart(string[] args)
    		{
    			Start();
    		}
    
    		public void Start()
    		{
    			// point the timer elapsed to the handler
    			timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
    			// turn on the timer
    			timer.Enabled = true;
    		}
    		
    		/// <summary>
    		/// This is called when the service is being stopped. 
                /// You need to wrap up pretty quickly or ask for an extension.
    		/// </summary>
    		protected override void OnStop()
    		{
    			timer.Enabled = false;
    		}
    
                /// <summary>
                /// Runs each time the timer has elapsed. 
                /// Remember that if the OnStop turns off the timer, 
                /// that does not guarantee that your process has completed. 
                /// If the process is long and iterative, 
                /// you may want to add in a check inside it 
                /// to see if timer.Enabled has been set to false, or 
                /// provide some other way to check so that 
                /// the process will stop what it is doing.
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
    		void timer_Elapsed(object sender, ElapsedEventArgs e)
    		{
    			MyFunction();
    		}
    
    		private int secondsElapsed = 0;
    		void MyFunction()
    		{
    			secondsElapsed += 10;
    		}
    	}
    }
