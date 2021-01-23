       protected static byte[] Convert(string wkhtmlPath, string switches, string html, string wkhtmlExe)
        {       
            // generate PDF from given HTML string, not from URL
            if (!string.IsNullOrEmpty(html))
            {               
                html = SpecialCharsEncode(html);
            }
            var proc = new Process();
            var StartInfo = new ProcessStartInfo();
            proc.StartInfo.FileName = Path.Combine(wkhtmlPath, wkhtmlExe);
            proc.StartInfo.Arguments = switches;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.WorkingDirectory = wkhtmlPath;
             
            proc.Start();
            // generate PDF from given HTML string, not from URL
            if (!string.IsNullOrEmpty(html))
            {
                using (var sIn = proc.StandardInput)
                {
                    sIn.WriteLine(html);
                }
            }
                     
            var ms = new MemoryStream();
            using (var sOut = proc.StandardOutput.BaseStream)
            {                              
                byte[] buffer = new byte[4096];
                int read;
                while ((read = sOut.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
            }
            string error = proc.StandardError.ReadToEnd();
            if (ms.Length == 0)
            {
                throw new Exception(error);
            }
            
            proc.WaitForExit();
                       
            return ms.ToString(); 
        }
       
        
        /// <summary>
        /// Encode all special chars
        /// </summary>
        /// <param name="text">Html text</param>
        /// <returns>Html with special chars encoded</returns>
        private static string SpecialCharsEncode(string text)
        {
            var chars = text.ToCharArray();
            var result = new StringBuilder(text.Length + (int)(text.Length * 0.1));
            foreach (var c in chars)
            {
                var value = System.Convert.ToInt32(c);
                if (value > 127)
                    result.AppendFormat("&#{0};", value);
                else
                    result.Append(c);
            }
            return result.ToString();
        }
        
    }
