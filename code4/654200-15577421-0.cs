     private void btn_submit_Click(object sender, EventArgs e)
    {
        copy_stuff(txt_src.Text, txt_dest.Text);
    }
    private void copy_stuff(string srcFolder, string destFolder)
    {
        foreach (string zzz in Directory.GetFiles(srcFolder, "*.zzz", SearchOption.AllDirectories))
        {
            string modulePath = Directory.GetParent(zzz).FullName;
            string moduleName = Directory.GetParent(zzz).Name;
            Directory.CreateDirectory(destFolder + "\\" + moduleName);
            foreach (string subFolders in Directory.GetDirectories(modulePath, "*", SearchOption.AllDirectories))
            {
                string dest = subFolders.Replace(modulePath, destFolder + "\\" + moduleName);
                Directory.CreateDirectory(dest);
                copy_stuff(subfolders, dest);
            }
            foreach (string allFiles in Directory.GetFiles(modulePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(allFiles, allFiles.Replace(modulePath, destFolder + "\\" + moduleName), true);
            }
        }
    }
