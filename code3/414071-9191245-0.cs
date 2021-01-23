            string input = "A-B-C";
            string s2;
            string s3 = "";
            string s4 = "";
            var splitted = input.Split('-');
            foreach(string s in splitted) {
                if (s.Length == 0)
                    s2 = String.Empty;
                else
                    if (s.Length > 1)
                        s2 = (s.First() + s.Last()).ToString();
                    else
                        s2 = s.First().ToString();
                s3 += s4 + s2;
                s4 = " and ";
            }
            int beginning;
            int end;
            if (input.Length > 1)
            {
                if ((input[0] + input[1]).ToString().Contains('-'))
                    beginning = 0;
                else
                    beginning = 1;
                if ((input[input.Length - 1] + input[input.Length - 2]).ToString().Contains('-'))
                    end = 0;
                else
                    end = 1;
            }
            else
            {
                if ((input[0]).ToString().Contains('-'))
                    beginning = 0;
                else
                    beginning = 1;
                if ((input[input.Length - 1]).ToString().Contains('-'))
                    end = 0;
                else
                    end = 1;
            }
            string result = s3.Substring(beginning, s3.Length - beginning - end);
