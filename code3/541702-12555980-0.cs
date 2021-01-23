     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Windows.Forms;
     namespace WindowsFormsApplication2
     {
	    public partial class Form3 : Form
	    {
	    	Server server;
	    	public Form3()
	    	{
	    		InitializeComponent();
    
    			server = new Server();
    
    			BackgroundWorker wrkr = new BackgroundWorker();
    			wrkr.WorkerReportsProgress = true;
    			wrkr.RunWorkerCompleted += new RunWorkerCompletedEventHandler(wrkr_RunWorkerCompleted);
    			wrkr.ProgressChanged += new ProgressChangedEventHandler(wrkr_ProgressChanged);
    			wrkr.DoWork += new DoWorkEventHandler(wrkr_DoWork);
    		}
    
    		void wrkr_DoWork(object sender, DoWorkEventArgs e)
    		{
    			// do work...perhaps you might be incrementing a progress meter...
    			for (int i = 0; i < 100; i++)
    			{
    				((BackgroundWorker)sender).ReportProgress(i,"Some message...");
    			}
    
    			e.Result = "some result...";
    		}
    
    		void wrkr_ProgressChanged(object sender, ProgressChangedEventArgs e)
    		{
    			// here you can use e.ProgressPercentage and e.UserState
    			// to change the state of something on the thread the worker was created on...
    			server.Percentage = e.ProgressPercentage;
    			server.Message = e.UserState.ToString();
    		}
    
    		void wrkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    		{
    			// here you can do some final stuff. clean-up etc.
    			server.Percentage = 100;
    			server.Message = e.Result.ToString();
    		}
    	}
    }
    
