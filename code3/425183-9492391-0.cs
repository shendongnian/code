        public void Parse(string killLog)
        {
            string[] parts = killLog.Split(new[] { " killed ", " with " }, StringSplitOptions.None);
            string player1 = parts[0].Substring(1, parts[0].IndexOf('<') - 1);
            string player2 = parts[1].Substring(1, parts[1].IndexOf('<') - 1);
            string weapon = parts[2].Replace("\"", "");
        }
