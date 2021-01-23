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
        textBox17.Text = dt.AddSeconds(1).ToString("HH:mm:ss");  // NOTE I GOT RID OF i - THAT WASN'T GOING TO WORK LIKE THAT - YOU JUST WANT TO ADD ONE SECOND BECAUSE THE TIMER TICKS EVERY SECOND
    }
    void buttonSetRtc_Click(object sender, EventArgs e)  // I HAVE NO IDEA WHAT YOUR METHOD HANDLER IS CALLED, THIS IS JUST FOR THE EXAMPLE
    {
        textBox17.Text = {some call to the microcontroller};  // HERE IS YOUR CALL TO THE MICROCONTROLLER FOR THE INITIAL TIME
        dt = DateTime.Parse(textBox17.Text);  // NOW THIS LINE WON'T FAIL
        rtc.Enabled = true;  // NOTE I MOVED THIS LINE TO KEEP IT FROM FAILING
    }
