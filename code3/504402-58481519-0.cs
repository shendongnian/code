                // getting keywords/functions
                string keywords = @"\b(abstract|as|base|break|case|catch|checked|continue|default|delegate|do|else|event|explicit|extern|false|finally|fixed|for|foreach|goto|if|implicit|in|interface|internal|is|lock|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sealed|sizeof|stackalloc|switch|this|throw|true|try|typeof|unchecked|unsafe|using|virtual|volatile|while)\b";
                MatchCollection keywordMatches = Regex.Matches(codeRichTextBox.Text, keywords);
                // getting types/classes from the text 
                string types = @"\b(Console)\b";
                MatchCollection typeMatches = Regex.Matches(codeRichTextBox.Text, types);
                // getting comments (inline or multiline)
                string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
                MatchCollection commentMatches = Regex.Matches(codeRichTextBox.Text, comments, RegexOptions.Multiline);
                // getting strings
                string strings = "\".+?\"";
                MatchCollection stringMatches = Regex.Matches(codeRichTextBox.Text, strings);
                string stringz = "bool|byte|char|class|const|decimal|double|enum|float|int|long|sbyte|short|static|string|struct|uint|ulong|ushort|void";
                MatchCollection stringzMatchez = Regex.Matches(codeRichTextBox.Text, stringz);
                // saving the original caret position + forecolor
                int originalIndex = codeRichTextBox.SelectionStart;
                int originalLength = codeRichTextBox.SelectionLength;
                Color originalColor = Color.Black;
                // MANDATORY - focuses a label before highlighting (avoids blinking)
                label1.Focus();
                // removes any previous highlighting (so modified words won't remain highlighted)
                codeRichTextBox.SelectionStart = 0;
                codeRichTextBox.SelectionLength = codeRichTextBox.Text.Length;
                codeRichTextBox.SelectionColor = originalColor;
                // scanning...
                foreach (Match m in keywordMatches)
                {
                    codeRichTextBox.SelectionStart = m.Index;
                    codeRichTextBox.SelectionLength = m.Length;
                    codeRichTextBox.SelectionColor = Color.Blue;
                }
                foreach (Match m in typeMatches)
                {
                    codeRichTextBox.SelectionStart = m.Index;
                    codeRichTextBox.SelectionLength = m.Length;
                    codeRichTextBox.SelectionColor = Color.DarkCyan;
                }
                foreach (Match m in commentMatches)
                {
                    codeRichTextBox.SelectionStart = m.Index;
                    codeRichTextBox.SelectionLength = m.Length;
                    codeRichTextBox.SelectionColor = Color.Green;
                }
                foreach (Match m in stringMatches)
                {
                    codeRichTextBox.SelectionStart = m.Index;
                    codeRichTextBox.SelectionLength = m.Length;
                    codeRichTextBox.SelectionColor = Color.Brown;
                }
                foreach (Match m in stringzMatchez)
                {
                    codeRichTextBox.SelectionStart = m.Index;
                    codeRichTextBox.SelectionLength = m.Length;
                    codeRichTextBox.SelectionColor = Color.Purple;
                }
                // restoring the original colors, for further writing
                codeRichTextBox.SelectionStart = originalIndex;
                codeRichTextBox.SelectionLength = originalLength;
                codeRichTextBox.SelectionColor = originalColor;
                // giving back the focus
                codeRichTextBox.Focus();
