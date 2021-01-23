    // Insert the line which will be the last line.
    richTextBox1.Select(0, 0);
    richTextBox1.SelectedRtf = rtfLines[0];
    // Prepend the other lines
    for (int i = 1; i < rtfLines.Length; i++) {
        richTextBox1.Select(0, 0);
        
        // Replace the ending "}\r\n" with "\\par }\r\n". "\\par" is a line break.
        richTextBox1.SelectedRtf =
            rtfLines[i].Substring(0, rtfLines[i].Length - 3) + "\\par }\r\n";
    }
