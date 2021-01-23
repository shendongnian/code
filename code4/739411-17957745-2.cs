    const int ITERATIONS_PER_UI_UPDATE = 20;
    using (System.IO.StreamReader file = new System.IO.StreamReader(@"T:\\PARTS\\DATABASE\\PARTS.txt"))
    {
        int count = 0;
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
            count++;
            if ((count % ITERATIONS_PER_UI_UPDATE) == 0))
            {
                 Action action = () => matchesText.Text = strBlder.ToString()
                 matchesText.Invoke(action);
            }     
        }
        Action action = () => matchesText.Text = strBlder.ToString()
        matchesText.Invoke(action);
    }
