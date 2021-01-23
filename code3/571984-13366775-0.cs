    public static string TransformLinqExample(this string toTransform)
            {
                string answer = toTransform
                    .ToCharArray()
                    .Select(c => new string(c, 1))
                    .Aggregate((a, c) => a += (CapitalLetters.Contains(c) && c.IsUpper() && !a.EndsWith("-") && !a.EndsWith(" ")) ? " " + c : "" + c);
                return answer;
            }
