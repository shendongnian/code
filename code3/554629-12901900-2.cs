            UnicodeEncoding uniencoding = new UnicodeEncoding();
            string filename = @"c:\Users\exampleuser\Documents\userinputlog.txt";
            byte[] result;
            using (FileStream SourceStream = File.Open(filename, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
            }
            UserInput.Text = uniencoding.GetString(result);
        }
