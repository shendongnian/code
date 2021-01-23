    else
    {
        ScrambleTextBoxText scrmbltb = new ScrambleTextBoxText(words[i]);
        scrmbltb.GetText();
        sb.Append(scrmbltb.scrambledWord);
        sb.Append(" ");
    }
    
...
    textBox2.AppendText(sb.ToString().Trim());
