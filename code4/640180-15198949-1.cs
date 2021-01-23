     public void UpdateResultsOnScreen(string newContent)
        {
            if(txtResults.InvokeRequired)
            {
                txtResults.Invoke(
                    new Action<string>(content => txtResults.Text += content), newContent);
                return;
            }
            txtResults.Text += newContent;
        }
