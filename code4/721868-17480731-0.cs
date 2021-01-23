            const string f = @"C:\Users.txt";
            string[] lines = System.IO.File.ReadAllLines(f);
            if (Array.IndexOf(lines, userBox.Text) != -1)
            {
                MessageBox.Show("correct");
            }
            else
            {
                MessageBox.Show("Not Correct");
            }
