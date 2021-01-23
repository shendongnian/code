    StringReader reader = new StringReader(input_TB.Text); 
    StringBuilder outputTxt = new StringBuilder();
    string compareTxt = inputCompare_TB.Text;
    string line; 
    while((line = reader.ReadLine()) != null) { 
      if (line.Contains(compareTxt)) {
        if (outputTxt.Length > 0)
          outputTxt.Append(Environment.NewLine);
        outputTxt.Append(line); 
      }
    } 
    output_TB.Text = outputTxt.ToString(); 
