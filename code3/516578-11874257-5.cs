    string[] words = new String[] {null, null, null, null};
    // as from John Saunders comment below, 
    // pass everything into a local temp variable to avoid double 
    // evaluation (and string rebuild) of the Trim() method
    string key1 = txtComKeyword1.Text.Trim();
    string key2 = txtComKeyword2.Text.Trim();
    string key3 = txtComKeyword3.Text.Trim();
    string key4 = txtComKeyword4.Text.Trim();
    words[0] = (key1.Length == 0 ? null : key1.ToLower());
    words[1] = (key2.Length == 0 ? null : key2.ToLower());
    words[2] = (key3.Length == 0 ? null : key3.ToLower());
    words[3] = (key4.Length == 0 ? null : key4.ToLower());
    if (words.Contains(itemDescription.ToLower())) 
        .....
