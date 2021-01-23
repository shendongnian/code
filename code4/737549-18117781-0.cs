    //Code to delete META-INF folder
    using (ZipFile zip = ZipFile.Read(jarFile))
    {
        List<string> files = zip.EntryFileNames.ToList<string>();
        List<string> delete = new List<string>();
        for (int i = 0; i < files.Count; i++)
        {
            if (files[i].Contains("META-INF"))
            {
                delete.Add(files[i]);
            }
        }
    zip.RemoveEntries(delete);
    zip.Save();
    }
    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
