        private IEnumerable<string> HandMadeSplit2b(string input)
        {
            //this one is margenaly better that the second best 2, but makes the resolver (its client much faster), nealy as fast as original.
            var Result = new List<string>();
            var begining = 0;
            var len = input.Length;
            for (var index=0;index<len;index++)
            {
                if (input[index] == '.')
                {
                    Result.Add(input.Substring(begining,index-begining));
                    begining = index+1;
                }
            }
            Result.Add(input.Substring(begining));
            return Result;
        }
