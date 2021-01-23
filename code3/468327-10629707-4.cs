    private bool checkNewGame = false;
    private void new_start()
    {        
        if(checkNewGame) return; 
        checkNewGame = true;    
        TimeSpan elapsedTime = DateTime.Now - startTime2;
        DialogResult result;
        result = MessageBox.Show("Your total time is " + ":" + elapsedTime.Minutes +   elapsedTime.Seconds
            + " would you like to play aigan?", "Application1", MessageBoxButtons.YesNo);
        if (result == DialogResult.No)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
        else if (result == DialogResult.Yes)
        {
           checkNewGame = true; 
           this.Close();
            
        }
