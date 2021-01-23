    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
       string temp = serialPort1.ReadExisting();
       if(temp == ";") //OK we have end of data lets process it
          splitAndDisplay();
       else
          TestText += temp; 
    }
    private void splitAndDisplay()
    {
       string[] nameArray = TestText.Split(new []{":", "*"}, StringSplitOptions.RemoveEmptyEntries);
       label3.Text = nameArray[0];
       posY.Text = nameArray[1];  
       posX.Text = nameArray[2];
       
       TestText = "";
    }
