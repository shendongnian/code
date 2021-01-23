    string t = (string)listBox1.SelectedItem;
    
    using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
    using (var sr = new StreamReader(store.OpenFile(t, FileMode.Open, FileAccess.Read)))
    {
        textBlock2.Text = sr.ReadToEnd();
    }
