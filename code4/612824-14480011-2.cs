    if (Directory.Exists(temp))
        {
            Directory.Delete(temp, true);
            Directory.CreateDirectory(temp);
        }
        using (ZipFile jar = ZipFile.Read(appdata + "\\.minecraft\\bin\\minecraft.jar"))
        {
            using (ZipFile zip = ZipFile.Read(ExistingZipFile))
            {
                zip.ExtractAll(temp, ExtractExistingFileAction.OverwriteSilently);
            }
            foreach (string file in Directory.GetFiles(temp))
            {
                if (jar.ContainsEntry(file))
                {
                    jar.RemoveEntry(file);
                }
                jar.AddFile(file, "\\");
            }
            jar.Save();
            MessageBox.Show("Entpacken der Dateien abgeschlossen!");
            label1.Text = "Entpacken abgeschlossen!";Solved the problem with this code(thanks to GemHunter1 :D ):
    
