                string number = "25274132531129322906392322409257377862778880";
                char[] strArr = number.ToCharArray();
                StringBuilder sb = new StringBuilder();
                foreach (char chr in strArr)
                {
                   sb.Append(Convert.ToString((int)Char.GetNumericValue(chr), 2));
                }
                string binresult = sb.ToString();
