    string unencryptedText;
        private void ReadTextFile()
        {
            
            using (StreamReader reader = new StreamReader("file.txt"))
            {
                unencryptedText= reader.ReadToEnd();
            }
        }
