    //Select the line from it's number
    int startIndex = richTextBox.GetFirstCharIndexFromLine(lineNumber);
    richTextBox.Select(startIndex, length);
    //Set the selected text fore and background color
    richTextBox.SelectionColor = System.Drawing.Color.White;
    richTextBox.SelectionBackColor= System.Drawing.Color.Blue;
