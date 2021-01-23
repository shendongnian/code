    using (System.IO.StreamReader file = new System.IO.StreamReader(@"T:\\PARTS\\DATABASE\\PARTS.txt"))
    {
        StringBuilder strBlder = new StringBuilder();
        while ((line = file.ReadLine()) != null)
        {
            if ((backgroundWorker1.CancellationPending == true))
            {
                e.Cancel = true;
            }
            else if (line.Contains(partNumbersText.Text))
            {
               strBlder.Append(line + Environment.NewLine);
            }               
        }
        Action action = () => matchesText.Text = strBlder.ToString()
        matchesText.Invoke(action);
    }
