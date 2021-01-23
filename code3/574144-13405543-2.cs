     privateasyncvoid Button_Click(object sender, RoutedEventArgs e)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            string filename = @"c:\Users\exampleuser\Documents\userinputlog.txt";
            byte[] result = uniencoding.GetBytes(UserInput.Text);
            using (FileStream SourceStream = File.Open(filename, FileMode.OpenOrCreate))
            {
                SourceStream.Seek(0, SeekOrigin.End);
                await SourceStream.WriteAsync(result, 0, result.Length);
            }
        }
