            string s = "-dsdsds-sdsds-grtt>";
            string output = null;
            if (s.Contains(">"))
            {
                output = s.Split(new string[] { ">" }, 
                                 StringSplitOptions.RemoveEmptyEntries)
                          .FirstOrDefault(i => i.Contains("-"));
                if (output != null)
                    output = output.Substring(output.LastIndexOf("-") + 1);
            }
