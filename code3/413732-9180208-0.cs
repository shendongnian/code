    RbLift1.Checked = true;
    lblLift1Current.Text = "Doors opening";
    timer1.Enabled = false; // stop the timer
    System.Threading.Thread.Sleep(5000); // wait 5 seconds for user input 
    timer1.Enabled = true; // start the timer again
    liftOne.FloorRequests.Remove(lift1.Value);
