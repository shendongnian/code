    try
        {
            //Initial opening point for save file dialogue
            saveFileDialog1.InitialDirectory = @"C:\Users\Heather\Documents\Visual Studio 2010\Projects\Random Number File Writer";
            //Save As popup - Opening the file for writing usage once it's created.
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                randomNumberFile = File.CreateText(saveFileDialog1.FileName);
                numbers = numericUpDown1.Value; //Gathering the number of numbers to generate from the number box.
                while (numbers > 0) // Loop counting down to 0 to give the user the appropriate number of requested random numbers.
                {
                    writeitem = rand1.Next(101); // Random number generated.
                    randomNumberFile.WriteLine(writeitem); //Random number written to file
                    numbers--; // Initial number for user input decremented so that loop will have an ending and user only gets the amount of randoms asked for.
                    randomNumberFile.Close();
                }
            }
            else // Popup informing user that the data will not save to a file because they didn't save.
            {
                MessageBox.Show("You elected not to save your data.");
            }
        }
