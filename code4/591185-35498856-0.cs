            // Loop through all words in the document.
            String read = string.Empty;
            List<string> data = new List<string>();
            for (int i = 0; i < document.Paragraphs.Count; i++)
            {
                string temp = document.Paragraphs[i + 1].Range.Text.Trim();
                if (temp != string.Empty)
                    data.Add(temp);
            }
            // Close word.
            application.Quit();
