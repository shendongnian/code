    void rfid_Tag(object sender, TagEventArgs e)
    {
    if(scantag == true)
    {        
    
    scantag = false;
    textBox4.Text = e.Tag;
    txtTag.Text = e.Tag;
    lastRFIDTag = txtTag.Text;
    rfid1.LED = true;       // light on
    }
    //wait for user to remove tag
    System.Threading.Thread.Sleep(5000);
    
    // enable the handler again
    scantag = true;
    
    }
