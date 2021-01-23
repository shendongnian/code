     public void UpdateResultsOnScreen(string newContent)
        {
            if(txtResults.InvokeRequired)
            {
                txtResults.Invoke(
                    new Action<string>((value) =>
                    {
                        txtResults.Text += value;
                    }),
                    newContent);
                return;
            }
           txtResults.Text += newContent;
        }
