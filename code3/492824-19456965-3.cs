    public void POSTagger_Method(string sent)
        {
            File.WriteAllText("POSTagged.txt", sent+"\n\n");
            string[] split_sentences = SplitSentences(sent);
            foreach (string sentence in split_sentences)
            {
                File.AppendAllText("POSTagged.txt", sentence+"\n");
                string[] tokens = TokenizeSentence(sentence);
                string[] tags = PosTagTokens(tokens);
                
                for (int currentTag = 0; currentTag < tags.Length; currentTag++)
                {
                    File.AppendAllText("POSTagged.txt", tokens[currentTag] + " - " + tags[currentTag]+"\n");
                }
                File.AppendAllText("POSTagged.txt", "\n\n");
            }
        }
