     List<string> words = new List<string>();
            String notes1="";
            int k;
            words.Add("The quick brown fox jumps over the lazy dog.");
            string the_word = words.ElementAt(words.Count - 1);
            MessageBox.Show(the_word);
            for (k = 0; k < words.Count / 3; k++)
            { notes1 += words.ElementAt(k) + ' '; }
            for (k = 0; k < words.Count / 3 + 1; k++)
            { notes1 += words.ElementAt(k) + ' '; }
