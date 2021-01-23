            string input = 
            @"As he didn't achieve success, he was fired.
            As he DIDN'T ACHIEVE SUCCESS, he was fired.
            As he Didn't Achieve Success, he was fired.
            As he Didn't achieve success, he was fired.";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("didn't achieve success", "failed miserably");
            string temp = input;
            foreach (var entry in map)
            {
                string key = entry.Key;
                string value = entry.Value;
                temp = Regex.Replace(temp, key, match =>
                {
                    bool isFirstUpper, isEachUpper, isAllUpper;
                    string sentence = match.Value;
                    char[] sentenceArray = sentence.ToCharArray();
                    string[] words = sentence.Split(' ');
                    isFirstUpper = char.IsUpper(sentenceArray[0]);
                    isEachUpper = words.All(w => char.IsUpper(w[0]) || !char.IsLetter(w[0]));
                    isAllUpper = sentenceArray.All(c => char.IsUpper(c) || !char.IsLetter(c));
                    if (isAllUpper)
                        return value.ToUpper();
                    if (isEachUpper)
                    {
                        // capitalize first of each word... use regex again :P
                        string capitalized = Regex.Replace(value, @"\b\w", charMatch => charMatch.Value.ToUpper());
                        return capitalized;
                    }
                    char[] result = value.ToCharArray();
                    result[0] = isFirstUpper
                        ? char.ToUpper(result[0])
                        : char.ToLower(result[0]);
                    return new string(result);
                }, RegexOptions.IgnoreCase);
            }
            textBox1.Text = temp; 
            /* output is :
            As he failed miserably, he was fired.
            As he FAILED MISERABLY, he was fired.
            As he Failed Miserably, he was fired.
            As he Failed miserably, he was fired.
            */
