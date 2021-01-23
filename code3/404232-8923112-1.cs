      var strFilePathAndName = "anyPathAndFilename"
      using (var fs = new System.IO.FileStream(strFilePathAndName, System.IO.FileMode.OpenOrCreate))
      {
         fs.Close();
      }
      // Create the writer for data.
      using ( var w = new System.IO.StreamWriter(strFilePathAndName, true))
      {
         w.Write(richTextBox1.Text);
         w.Write(richTextBox2.Text);
         w.Write(checkBox1.Checked.toString());
         w.Close();
      }
