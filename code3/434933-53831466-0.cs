        public static IList<ArraySegment<T>> Split<T>(this T[] arr, params T[] delimiter)
        {
            
            var result = new List<ArraySegment<T>>();
            var segStart = 0;
            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                //If is match
                if (arr.Skip(i).Take(delimiter.Length).SequenceEqual(delimiter))
                {
                    //Skip first empty segment
                    if (i > 0)
                    {
                        result.Add(new ArraySegment<T>(arr, segStart, i - segStart));
                    }
                    //Reset
                    segStart = i;
                }      
            }
            //Add last item
            if (segStart < arr.Length)
            {
                result.Add(new ArraySegment<T>(arr, segStart, arr.Length - segStart));
            }
            return result;
        }
