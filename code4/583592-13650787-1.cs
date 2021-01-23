    string line;
    System.IO.StreamReader file = new System.IO.StreamReader(strfn);
    while((line = file.ReadLine()) != null)
    {
      this.richTextBox1.AppendText(line+"\n");//you can replace this line to fit your UseCase
    }
