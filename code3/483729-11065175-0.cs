    private void methodName()
    {
        for (int i = 0; i < 2; i++)
        {
            updateTextBox(i.ToString());
 
            canvas.UpdateLayout();
            PrintDialog dialog = new PrintDialog();
            dialog.PrintVisual(this.canvas, "ABC");
            dialog.PrintQueue.Refresh();
            
            while (dialog.PrintQueue.NumberOfJobs != 0)
            {
                bool isQueued = false;
                foreach (var job in dialog.PrintQueue.GetPrintJobInfoCollection())
                {
                    if (job.Name == "ABC")
                        isQueued = true;
                }
                if (!isQueued)
                    break;
                Thread.Sleep(500);
                dialog.PrintQueue.Refresh();
            }
        }
    }
    private void updateTextBox(string text)
    {
        txtTextBox.Text = text;
    }
