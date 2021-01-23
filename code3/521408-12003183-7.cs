            // If there are mixed interval types in an input string
            string input = "10 days and 10 hours ago";
            // Parse out the intervals and numbers
            var matches = Regex.Matches(input, 
                           @"(?<number>\d+)\s(?<interval>(day)|(minute)|(hour))");
            
            // Convert them to dictionary
            var dic = matches
                .Cast<Match>()
                .ToDictionary(
                    key => key.Groups["interval"].Value, 
                    o => int.Parse(o.Groups["number"].Value));
            
            // Calculate the total number of minutes for each interval
            DateTime result = DateTime.MinValue;
            int totalMinutes = 0;
            foreach (var keyValue in dic)
            {
                 if (keyValue.Key.Contains("minute"))
                     totalMinutes += keyValue.Value;
                else
                     if (keyValue.Key.Contains("hour"))
                        totalMinutes += keyValue.Value * 60;
                    else
                         if (keyValue.Key.Contains("day"))
                            totalMinutes += keyValue.Value * 1440;
                        else
                            throw new Exception("Unparsable time format");
            }
            
            result = DateTime.Now.AddMinutes(-totalMinutes);
