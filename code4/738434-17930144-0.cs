    if (File.Exists(@"C:\ESC\Impostazioni.txt"))
    {
        using (var letterFile = new StreamReader(@"C:\ESC\Impostazioni.txt"))
        {
            var opzioni = letterFile.ReadLine();
            
            if(string.IsNullOrWhiteSpace(opzioni))
            {
                // end of file
            }
            
            var dashIndex = opzioni.IndexOf("-");
            
            string coloregenerale = dashIndex > -1
                                        ? opzioni.Substring(0, dashIndex)
                                        : opzioni;
        }
    }
