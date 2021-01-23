    string[] wordsToBeRemoved = { "word 1", ":", "'", "," };
    string result = lines[4];
    foreach (string toBeRemoved in wordsToBeRemoved) {
        result = result.Replace(toBeRemoved, string.Empty);
    }
    textBox1.Text += result;
