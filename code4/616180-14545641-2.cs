                    private bool paused;
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
                
                            //Timestamp checkbox
                	        if (checkBox3.Checked)
                		    {
                				//Display timestamp using DateTime.Now
                					
                			}
                
                			//Write to file checkbox
                			if (checkBox4.Checked)
                			{
                				using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                				{
                					file.WriteLine(indata);
                				} 
                			}
                    	}
                    }
                     		
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
               }
