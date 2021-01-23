    if(String.IsNullOrWhiteSpace(path)) // path contains a path. Save changes instead of creating NEW file.
    {
       File.WriteAllText(path, content);
    }
    else if (!String.IsNullorWhiteSpace(editor.Text))
    {
       // no path defined. Create new file and write to it.
       using(SaveFileDialog saver = new SaveFileDialog())
       {
          if(saver.ShowDialog() == DialogResult.OK)
          {
             File.WriteAllText(saver.Filename, content);
          }
       }
    }
