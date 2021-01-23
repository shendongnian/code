    foreach (string line in File.ReadLines(currentFile))
    {
      lineNumber++;
      if (line.Contains(textToSearch))
      {
        var lineNumberCopy = lineNumber;
        lbFiles.Dispatcher.BeginInvoke((Action)(() =>
        {
          //add the file name and the line number to a ListBox
          lbFiles.Items.Add(currentFile + "     " + lineNumberCopy );
        }));
      }
    }
