    Using System.IO
    
    protected void ListFiles()
    {
            const string MY_DIRECTORY = "/MyDirectory/";
            string strFile = null;
            foreach (string s in Directory.GetFiles(Server.MapPath(MY_DIRECTORY), "*.*")) {
                    strFile = s.Substring(s.LastIndexOf("\\") + 1);
                    ListBox1.Items.Add(strFile);
            }
    
