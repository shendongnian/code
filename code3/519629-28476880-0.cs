            string str = System.IO.File.ReadAllText(strFile);
            str = str.Replace("\n", "");
            str = str.Replace("\r", "");
            Regex regex = new Regex(@">\s*<");
            string cleanedXml = regex.Replace(str, "><");
            System.IO.File.WriteAllText(strFile, cleanedXml);
        }
