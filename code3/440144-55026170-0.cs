            using (TextReader reader = File.OpenText(file))
            {
                // remove commas and double quotes inside file
                var pattern = @"\""(.+?,.+)+\""";
                var results = Regex.Replace(reader.ReadToEnd(), pattern, match => match.Value.Replace(",", " "));
                results = results.Replace("\"", "");
             }
