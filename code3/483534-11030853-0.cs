    foreach (string word in words)
    {
        int blacklist = 0;
        if (FindMyText(word))
        {
            blacklist = 1;
            MessageBox.Show("Current word: " + word + " is blacklisted!");
            // skip to the next element
            continue;
        }
        
        MessageBox.Show("Word: " + word);
        // the code here ... for writing in file and all that
    
    }
