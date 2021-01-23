    string sName;
    
                //asks user to input their name before the game begins
                sName = Microsoft.VisualBasic.Interaction.InputBox("Please enter your name:", "What is Your Name?", "");
                //if no name is entered, they are asked again
                       while (sName == "")
                        {
                        MessageBox.Show("Please enter your name.");
                        sName = Microsoft.VisualBasic.Interaction.InputBox("Please enter your name:", "What is Your Name?", "");
                         }
