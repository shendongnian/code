    string word = textBox1.Text.Trim();
    bool containUnicode = false;
    for (int x = 0; x < word.Length; x++)
    {
        if (char.GetUnicodeCategory(word[x]) == UnicodeCategory.OtherLetter)
        {
            containUnicode = true;
            break;
        }
    }
    if (containUnicode)
    {
        MessageBox.Show("contain unicode");
    }
    else
    {
        MessageBox.Show("does not contain unicode");
    }
