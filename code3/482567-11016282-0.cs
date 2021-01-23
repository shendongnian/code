    private void loadtest_Click(object sender, EventArgs e)
            {
    
         IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                    if (storage.FileExists("test.xml"))
                    {
    
              IsolatedStorageFileStream fileStream = storage.OpenFile("test.xml", FileMode.Open, FileAccess.ReadWrite);
    
                    XDocument test = XDocument.Load(fileStream);
                     string score = test.Root.Value.ToString();
    
                   string[] scores = score.Split(',');
                   foreach (string s in scores)
                   {
                      lbTestAScore.Text= scores[0].ToString();
                      lbTestBScore.Text = scores[1].ToString();
                   }
