            string haystack = "127.0.0.1:8080 this is some ip and port 127.0.0.1";
            Regex needle = new Regex("[0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}([:][0-9]{2,5})?");
            string output = String.Empty;
            string[] lines = haystack.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (needle.IsMatch(line))
                {
                    output += needle.Match(line).ToString() + Environment.NewLine;
                }
            }
            // output 127.0.0.1:8080
