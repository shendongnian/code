    string uniquePath = string.Format(@"C:\{0}", Guid.NewGuid());
    System.IO.Directory.CreateDirectory(uniquePath);
    using (ZipFile zip = ZipFile.Read(textBox1.Text))
        {
            System.IO.Directory.SetCurrentDirectory(uniquePath);
            zip.ExtractSelectedEntries("name = *.xml",,ExtractExistingFileAction.OverwriteSilently);
        }
          
