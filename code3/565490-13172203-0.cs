        public static string MyTrim1(string commandText, string trimmer)
        {
            if (String.IsNullOrEmpty(commandText) || String.IsNullOrEmpty(trimmer))
            {
                return commandText;
            }
            string reversedCommand = (string.Concat(commandText.Reverse())).ToUpper();
            trimmer = trimmer.ToUpper();
            if (trimmer.Reverse().Where((currentChar, i) => reversedCommand[i] != currentChar).Any())
            {
                return commandText;
            }
            else
            {
                return commandText.Substring(0, commandText.Length - trimmer.Length);
            }
        }
