    label1.Text = "Entpacken....."; //In der Box
    progressBar1.Visible = false;
    button3.Visible = true;
    MessageBox.Show("Download abgeschlossen!!\n\rBitte warte bis der Launcher die Dateien   entpackt hat."); // Erklärt sich von selbst
    string ExistingZipFile = @"Test.zip";
    string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    using (ZipFile jar = ZipFile.Read(appdata + "\\.minecraft\\bin\\minecraft.jar"))
    {
      using (ZipFile zip = ZipFile.Read(ExistingZipFile))
      {
          zip.ExtractAll(Path.GetTempPath() + "\\zip\\");
      }
    foreach (string file in Directory.GetFiles(Path.GetTempPath() + "\\zip\\"))
    {
      if (jar.ContainsEntry(file))
      {
         jar.RemoveEntry(file);
      }
      jar.AddFile(file);
    }
    jar.Save();
    MessageBox.Show("Entpacken der Dateien abgeschlossen!");
    label1.Text = "Entpacken abgeschlossen!";
    
