    /// <summary>
            /// Compares using binary search
            /// </summary>
            /// <param name="input"> search input</param>
            /// <param name="reference"> reference string</param>
            /// <returns> returns true or false</returns>
            public bool FatMan(string input, string reference)
            {
                string[] temp = reference.Split();
                Array.Sort(temp);
                List<string> refe = new List<string> { };
                refe.AddRange(temp);
    
                string[] subip = input.Split();
                foreach (string str in subip)
                {
                    if (refe.BinarySearch(str, StringComparer.OrdinalIgnoreCase) < 0)
                    {
                        return false;
                    }
                }
    
                return true;
            }
    
            /// <summary>
            /// compares using contains method
            /// </summary>
            /// <param name="input"> search input</param>
            /// <param name="reference"> reference string</param>
            /// <returns> returns true or false</returns>
            public bool Hiroshima(string input, string reference)
            {
                string[] temp = reference.Split();
                Array.Sort(temp);
                List<string> refe = new List<string> { };
                refe.AddRange(temp);
                string[] subip = input.Split();
    
                foreach (string str in subip)
                {
                    if (!refe.Contains(str, StringComparer.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
    
                return true;
            }
    
    
            public bool Nakashaki(string input, string reference)
            {
                string[] temp = reference.Split();
                Array.Sort(temp);
                List<string> refe = new List<string> { };
                refe.AddRange(temp);
                string[] subip = input.Split();
    
                int result = (from st in subip where temp.Contains(st, StringComparer.OrdinalIgnoreCase) select st).Count();
    
                if (result <= 0)
                {
                    return false;
                }
    
                return true;
            }
    
            /// <summary>
            /// compares using contains method
            /// </summary>
            /// <param name="input"> search input</param>
            /// <param name="reference"> reference string</param>
            /// <returns> returns true or false</returns>
            public bool LittleBoy(string input, string reference)
            {
                string[] subip = input.Split();
                foreach (string str in subip)
                {
                    if (!reference.Contains(str))
                    {
                        return false;
                    }
                }
    
                return true;
            }
