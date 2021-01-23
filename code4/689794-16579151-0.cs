    public void ConsoleEnter_KeyDown(object sender, KeyEventArgs e)
        {
            string line;
            if (e.KeyCode == Keys.Enter)
            {
    
                // Read the file and display it line by line.
                StreamReader file = new StreamReader("C:\\Users\\Home\\Desktop\\commands.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(ConsoleEnter.Text))
                    {
                        COMBOX.Items.Add(ConsoleEnter.Text);
                    }
                    else
                    {
                        COMBOX.Items.Add("Invalid Command");
                    }
                }
                COMBOX.Items.Remove("");
                ConsoleEnter.Text = "";
            }
        }
