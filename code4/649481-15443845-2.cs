    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        string sourcePath = @"C:\temp\";
        this.DirSearch(sourcePath);
    }
    private void DirSearch(string sDir) 
    {
        try	
        {
            foreach (string d in Directory.GetDirectories(sDir)) 
            {
                foreach (string f in Directory.GetFiles(d, txtFile.Text)) 
                {
                    lstFilesFound.Items.Add(f);
                }
                this.DirSearch(d);
            }
        }
        catch (System.Exception excpt)
        {
            listBox1.Items.Add(ex.Message);
        }
    }
