            String _userName = "User";
            String _newPassword = "Password";
            // Reading All line from file
            String _fileContent = System.IO.File.ReadAllLines("filePath").ToString();
            // Pattern which user password like to changed            
            string _regPettern = String.Format(@"{0} ?(?<pwd>\w+)[\s\S]*?", _userName);
            Regex _regex2 = new Regex(_regPettern, RegexOptions.IgnoreCase);
            String _outPut = Regex.Replace(_fileContent, _regPettern, m => m.Groups[1] + " " + _newPassword);
            // Writing to file file
            System.IO.File.WriteAllText("filePath", _outPut);
