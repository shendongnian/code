    //The code should be placed in Form load, if placing in form Constructor, the result may be not expected.
    private void Form1_Load(object sender, EventArgs e){ 
      //This will place button1 over button2
      button1.Location = groupBox1.PointToClient(groupBox2.PointToScreen(button2.Location));
    }
