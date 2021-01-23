    //creat directory for folders
    if (!Directory.Exists(@"C:\Users\TomJ\Record My Life files")) 
    {
    }
    else
    {
       Directory.CreateDirectory(@"C:\Users\TomJ\Record My Life files");
       MessageBox.Show("Directory Created for Diary Entries");
    }
    private void savebutton_Click_1(object sender, EventArgs e)
    {
      try
      {
        string content = new TextRange(reviewtxtbox.Document.ContentStart, reviewtxtbox.Document.ContentEnd).Text;
        string date = datepckr.Text;
        string time = timetxtbox.Text;
        string path = @"C:\Users\TomJ\Record My Life files\" + date + time + ".txt";
        File.WriteAllLines(path,content);
        MessageBox.Show("Your day has been saved!");
      }
      catch(Exception etc)
      {
        MessageBox.Show("An error Ocurred: " + etc.Message);
      }
    }
