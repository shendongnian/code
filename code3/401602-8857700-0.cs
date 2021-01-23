            match = Regex.Match(input, @"Type1|Type2|Type3");
            if (match.Success)
            {
                // loop, in case you are matching to multiple occurrences within the input.
                // However, Regex.Match(string, string) will only match to the first occurrence.
                foreach (Capture capture in match.Captures)
                {
                    // if you care to determine which one (Type1, Type2, or Type3) each capture is
                    switch (capture.Value)
                    {
                        case "Type1":
                            // ...
                            break;
                        case "Type2":
                            // ...
                            break;
                        case "Type3":
                            // ...
                            break;
                    }
                }
            }
