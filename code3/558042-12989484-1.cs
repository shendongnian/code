    System.IO.StreamReader file = new System.IO.StreamReader(@"d:\test.txt");
    while (file.EndOfStream != true)
    {
        //This will give you the two words from the line in an array
        //note that this counts on your file being perfect. You should probably check to make sure that the line you read in actually produced two words.
        string[] words = file.ReadLine().Split(' ');
        string replacedWord = Regex.Replace(richTextBox3.Text, words[0], words[1], RegexOptions.IgnoreCase);
        richTextBox3.Text = replacedWord;
    }
