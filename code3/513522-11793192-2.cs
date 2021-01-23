    System.Windows.Forms.Timer rtc = null; 
    DateTime dt;  // NOTE I DON'T INITIALIZE THIS TO ANYTHING AT FIRST
    private void StartRTC() 
    { 
        rtc = new System.Windows.Forms.Timer(); 
        rtc.Interval = 1000; 
        rtc.Tick += new EventHandler(rtc_Tick); 
    } 
    void rtc_Tick(object sender, EventArgs e) 
    { 
        // NOTE I GOT RID OF i - THAT WASN'T GOING TO WORK LIKE THAT 
        // YOU JUST WANT TO ADD ONE SECOND BECAUSE THE TIMER TICKS EVERY SECOND:
        textBox17.Text = dt.AddSeconds(1).ToString("HH:mm:ss");
        dt = DateTime.Parse(textBox17.Text);
    }
     // I HAVE NO IDEA WHAT YOUR METHOD HANDLER IS CALLED, THIS IS 
     // JUST FOR THE EXAMPLE
    void buttonSetRtc_Click(object sender, EventArgs e)  
    {
        // HERE IS YOUR CALL TO THE MICROCONTROLLER FOR THE INITIAL TIME:
        textBox17.Text = {some call to the microcontroller};  
        dt = DateTime.Parse(textBox17.Text);  // NOW THIS LINE WON'T FAIL
        rtc.Enabled = true;  // NOTE I MOVED THIS LINE TO KEEP IT FROM FAILING
    }
