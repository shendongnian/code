    StringBuilder outputTxt = new StringBuilder();
    string txt = input_TB.Text;
    int txtIndex = 0;
    while (txtIndex < txt.Length) {
      int startLineIndex = txtIndex;
    GetMore:
      while (txtIndex < txt.Length && txt[txtIndex] != '\r'  && txt[txtIndex] != '\n')) {
        txtIndex++;
      }
      if (txtIndex < txt.Length && txt[txtIndex] == '\r' && (txtIndex == txt.Length-1 || txt[txtIndex+1] != '\n') {
        txtIndex++;
        goto GetMore; 
      }
      string line = txt.Substring(startLineIndex, txtIndex-startLineIndex);
      if (line.Contains(inputCompare_TB.Text)) {
        if (outputTxt.Length > 0)
          outputTxt.Append(Environment.NewLine);
        outputTxt.Append(line); 
      }
      txtIndex++;
    } 
    output_TB.Text = outputTxt.ToString(); 
