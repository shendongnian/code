      TextReader myInputFile = new StreamReader("test.xml");
      TextWriter myOutputFile = new StreamWriter("newtest.xml");
      myOutputFile.WriteLine(myInputFile.ReadLine());
      myOutputFile.WriteLine("<content xmlns=\"http://url.com/path_v1_0\">");
      string line = myInputFile.ReadLine(); // Waste the original <content> line
      while ((line = myInputFile.ReadLine()) != null)
      {
        myOutputFile.WriteLine(line);
      }
      myInputFile.Close();
      myOutputFile.Close();
