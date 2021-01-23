    StringBuilder sb = new StringBuilder();
    var words = textBox1.Text.Split(new char[] { ' ', '"', ',',etc. },
        StringSplitOptions.RemoveEmptyEntries);
    int index = 0;
    int prevIndex = 0;
    int prevWordWidth = 0;//This variable is now kept across iterations
    for (int i = 0; i < words.Length; i++)
    {
        string word = words[i];
                
        //The non-scrambled string is from end of last word (prevIndex+prevWordWidth) 
        //up to the next word (index)
        index = textBox1.Text.IndexOf(word, prevIndex+prevWordWidth);
        string t = textBox1.Text.Substring(prevIndex+prevWordWidth, index-(prevIndex+prevWordWidth));
        
        prevIndex = index;
        prevWordWidth = word.Length;
        sb.Append(t);
        string s = textBox1.Text.Substring(index, prevWordWidth);
        if (index == -1) break;
        if (word.Length > 0)
        {
            ScrambleTextBoxText scrmbltb = new ScrambleTextBoxText(s.Trim());
            scrmbltb.GetText();
            sb.Append(word.Replace(s.Trim(), scrmbltb.scrambledWord));             
        }
    }
    textBox2.Text = sb.ToString(); //Note how this is only set at the end.
