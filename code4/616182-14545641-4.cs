    private bool paused;
    private SerialPort sp;
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
            //To avoid cross thread problems do something like this
            Invoke(new Action(() =>
            {
	            textBox1.Text += indata;
            }));
            //Or if you are just writing to the console 
            Console.WriteLine(indata); //Thread safe
            //Timestamp checkbox
            if (checkBox3.Checked)
            {
                //Display timestamp using DateTime.Now	
            }
		//Write to file checkbox
		if (checkBox4.Checked)
		{
			using (StreamWriter file = new StreamWriter(path, true))
			{
				file.WriteLine(indata);
			} 
		}
	}
    }
         		
    //Pause/Resume Checkbox
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
    	paused = checkBox1.Checked;
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
