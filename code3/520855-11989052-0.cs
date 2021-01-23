            using System.Text.RegularExpressions;
            string pattern = @"([a-z0-9A-Z]{3})([a-z0-9A-Z]{3})
                        ([a-z0-9A-Z]{2})([a-z0-9A-Z]{3})([a-z0-9A-Z]{3})"
            string oldFormat = "949123U0456789";
            string newFormat = Regex.Replace(oldFormat, pattern, 
                        "$1.$2-$3-$4.$5");
