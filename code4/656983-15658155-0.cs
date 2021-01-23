    private string[] paragraphs;
    private int index = 0;
    private void LoadFile_Click(object sender, EventArgs e)
    {
       OpenFileDialog dialog = new OpenFileDialog();
       dialog.Filter =
          "txt files (*.txt)|*.txt|All files (*.*)|*.*";
       dialog.Title = "Select a text file";
       dialog.ShowDialog();
       if (dialog.FileName != "")
       {
           System.IO.StreamReader reader = new System.IO.StreamReader(dialog.FileName);
           string Text = reader.ReadToEnd();
           reader.Close();
           this.Input.TextChanged -= new System.EventHandler(this.Input_TextChanged);
           Input.Clear();
           paragraphs = Text.Split('\n');
           index = 0;
           Input.Text = paragraphs[index];
       } 
    } 
    
    private void Next_Click(object sender, EventArgs e)
    {
       index++;
       Input.Text = paragraphs[index];
    }
