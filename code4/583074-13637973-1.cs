        static private int[] SplitStringToNumbersArray(string _Numbers)
        {
            _Numbers = _Numbers.Replace("  ", " "); 
            string[] pieces = _Numbers.Split(' ');
            int[] ret = new int[pieces.Length];
            for (int i = 0; i < pieces.Length; i++)
            {
                ret[i] = int.Parse(pieces[i]);
            }
            return ret;
        }
