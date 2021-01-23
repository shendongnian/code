    Button c;
    // here you look for a Button within the Controls of your Form. It stops when an Enabled Button with Text != "X" is found
    do
    {
        c = this.Controls.FindControl("btn" + Convert.ToString(RandomGenerator.GenRand(1, 9))) as Button;
    } while (c == null || !c.Enabled || c.Text == "X");
    c.Text = "O"; //O will be inside the button
    c.Enabled = false; //button can no long be used
    CheckComputerWinner(); //check if it finishes task
    return;
