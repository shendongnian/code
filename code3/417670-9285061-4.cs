    // Inside the form class:
     
    private System.Diagnostics.Process proc;
     
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
        button3.BackColor=Color.LightGreen;  //success indicator
    }
