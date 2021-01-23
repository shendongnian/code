            List<string> files = new List<string>();
            string[] parts = htmlText.Split(new string[]{"\""},                
                 StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                if (part.EndsWith(".exe"))
                    files.Add(part);
            }
