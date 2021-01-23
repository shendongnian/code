      var strFilePathAndName = "anyPathAndFilename"
      var fs = new System.IO.FileStream(strFilePathAndName, System.IO.FileMode.OpenOrCreate);
      fs.Close();
      
      // Create the writer for data.
      var w = new System.IO.StreamWriter(strFilePathAndName, true);
      w.Write(richTextBox1.Text.toString());
      w.Write(richTextBox2.Text.toString());
      w.Write(checkBox1.Value.toString());
      w.Close();
