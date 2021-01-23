      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "Text File|*.txt";
      ofd.FileName = "File";
    
      StringBuilder Sb = new StringBuilder();
    
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
        using (StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName))) {
          while (!sr.EndOfStream)
            if (Sb.Length > 0) {
              Sb.AppendLine();
              Sb.Append(sr.ReadLine());
            }
            else
              Sb.Append(sr.ReadLine());
        }
    
        richTextBox1.Text += Sb.ToString();
      }
