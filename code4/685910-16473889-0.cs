            private void Trial()
            {
                DateTime saveNow = DateTime.Today;
                DateTime expiryDate = DateTime.Today.AddDays(30);
                string fileName = System.IO.Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"623231489374524.txt");
                var lastLine = File.ReadLines(fileName).Last();
                string Enddate = lastLine;
                DateTime TrialOver = Convert.ToDateTime(Enddate);  
                if (!File.Exists(fileName))
                {
                    // Write the string to a file.
                    System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
                    file.WriteLine(saveNow);
                    file.WriteLine(expiryDate);
    
                    file.Close();
                }
                else if (File.Exists(fileName))
                {
                    if (saveNow == TrialOver)
    {
        MessageBox.Show("Trial mode is over.");
    }
                }
            }
