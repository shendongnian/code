        SerialPort sp;
    		public Form1()
    		{
    			InitializeComponent();
    			sp = new SerialPort();
    			sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
    		}
    
    		private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    		{
    			if (!paused)
    			{
    				string indata = sp.ReadExisting();
    				//Display the data
    			}
    		}
    
    		private bool paused;
    //Pause/Resume Checkbox
    		private void checkBox1_CheckedChanged(object sender, EventArgs e)
    		{
    			if (checkBox1.Checked)
    			{
    				paused = true;
    			}
    			else
    			{
    				paused = false;
    			}
    		}
    
    //Connect/Disconnect checkbox
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        		{
        			if (checkBox2.Checked)
        			{
        				sp.Open();
        			}
        			else
        			{
        				sp.Close();
        			}
        		}
