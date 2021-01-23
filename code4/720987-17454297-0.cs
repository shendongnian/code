     if (string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(editor.Text))
     {
           // no path defined. Create new file and write to it.
           using (SaveFileDialog saver = new SaveFileDialog())
           {
                if (saver.ShowDialog() == DialogResult.OK)
                {
                     File.WriteAllText(saver.Filename, content);
                }
           }                
      }
      else if(File.Exists(path)
      {
           File.WriteAllText(path, content);
      }
