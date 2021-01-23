        // Goes through a string from end to start, looking for the last digit character.
        // It then adds 1 to it and returns the result string.
        // If the digit was 9, it turns it to 0 and continues,
        // So the digit before that would be added with one.
        // Overall, it takes the last numeric substring it finds in the string,
        // And replaces it with itself + 1.
        private static unsafe string Foo(string str)
        {
            var added = false;
            fixed (char* pt = str)
            {
                for (var i = str.Length - 1; i >= 0; i--)
                {
                    var val = pt[i] - '0';
                    // Current char isn't a digit
                    if (val < 0 || val > 9)
                    {
                        // Digits have been found and processed earlier
                        if (added)
                        {
                            // Add 1 before the digits,
                            // Because if the code reaches this,
                            // It means it was something like 999,
                            // Which should become 1000
                            str = str.Insert(i + 1, "1");
                            break;
                        }
                        continue;
                    }
                    added = true;
                    // Digit isn't 9
                    if (val < 9)
                    {
                        // Set it to be itself + 1, and break
                        pt[i] = (char)(val + 1 + '0');
                        break;
                    }
                    // Digit is 9. Set it to be 0 and continue to previous characters
                    pt[i] = '0';
                    // Reached beginning of string and should add 1 before digits
                    if (i == 0)
                    {
                        str = str.Insert(0, "1");
                    }
                }
            }
            return str;
        }
