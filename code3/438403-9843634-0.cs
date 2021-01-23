    static void populateZipCodeDictionary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
            MessageBox.Show(e.Error.ToString());
        else
            MessageBox.Show("Dictionary loaded");
    }
