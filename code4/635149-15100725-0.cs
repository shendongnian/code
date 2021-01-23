    var wordApplication = new Application() { Visible = true };
    var myDocument = wordApplication.Documents.Open(@"C:\Users\...\my.docx");
    
    for (var i = 1; i <= myDocument.Paragraphs.Count; i++)
    {
        var paragraph = myDocument.Paragraphs[i];
        var words = paragraph.Range.Words.Cast<Range>().Select(r => r.Text).ToList();
    
        // Empty paragraph -> continue
        if(words.Count == 1 && words[0] == "\r")
            continue;
    
        for (var j = 0; j < words.Count; j++)
        {
            var word = words[j];
    
            // Should not be reversed
            if(word == "\r")
                continue;
    
            var reversed = new string(word.Trim().Reverse().ToArray());
    
            words[j] = (word.EndsWith(" ")) ? reversed + " " : reversed;
        }
    
        paragraph.Range.Text = string.Join("", words);
    }
