    public void GetFolder()
        { 
             var dict = new Dictionary<string, string>();
             ArrayList arr = new ArrayList();
             foreach (Folder folder in rootfolder.FindFolders(new FolderView(100)))
                {
                 dict.Add(folder.Id.ToString(),folder.DisplayName);
                 arr.Add(folder.Id.ToString());
                }        
    
           checkedListBox1.DataSource = new BindingSource(dict, null);
           checkedListBox1.DisplayMember = "Value";
           checkedListBox1.ValueMember = "Key";
           
           //Do whatever to arraylist..
        }
