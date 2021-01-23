    if (Microsoft.Phone.Info.DeviceStatus.DeviceName == "Windows Phone 8X by HTC")
        /* DO NOTHING */;
    /* Regular, Unconditional Code */
    {
        //Debugging MSG
        MessageBox.Show("8X Works")
        //Rating
        MainScore.Text = "6.1";
        //Subscores
        Processor.Text = "5.2";
        RAM.Text = "6.5";
        Graphics.Text = "8.0";
        HardDisk.Text = "5.1";
        //Issues
        Issues.Text = "0 ISSUES FOUND";
    }
 
    if (Microsoft.Phone.Info.DeviceStatus.DeviceName == "Windows Phone 8S by HTC")
        /* DO NOTHING */;
    /* Regular Unconditional code */
    {
       //Debugging MSG
       MessageBox.Show("8S Works")
       //Rating
       MainScore.Text = "2.8";
       //Subscores
       Processor.Text = "3.2";
       RAM.Text = "2.4";
       Graphics.Text = "4.0";
       HardDisk.Text = "1.9";
       //Issues
       Issues.Text = "0 ISSUES FOUND";
     }
