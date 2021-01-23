    protected void btnShow_Click(object sender, EventArgs e)
    {
        using (var writer = new StreamWriter(Server.MapPath(@"~/Puzzle/puzzle.txt")))
        {
            int recordsWritten = 0;
            foreach (Control control in Panel1.Controls)
            {
                var textBox = control as TextBox;   
                if (textBox != null)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        textBox.Style["visibility"] = "hidden";
                    }
                    stringWriter.Write(textBox.Text + ",");
    
                    recordsWritten++;
                    if (recordsWritten == 4)
                    {
                        stringWriter.WriteLine();
                        recordsWritten = 0;
                    }
                }
            }
        }
    }
