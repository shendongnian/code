    // path contains a path. Save changes instead of creating NEW file.
    if(!String.IsNullOrWhiteSpace(path))
    {
       File.WriteAllText(path, content);
    }
    else
    {
       // no path defined. Create new file and write to it.
       using(SaveFileDialog saver = new SaveFileDialog())
       {
          if(saver.ShowDialog() == DialogResult.OK)
          {
             File.WriteAllText(saver.FileName, content);
          }
       }
    }
