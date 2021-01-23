    public static List<int> RemoveSequencialRepeats(List<int> input)
            {
                var result = new List<int>();
    
                result.Add(input.First());
                foreach (var element in input.Where(p_element => result.Last() != p_element))
                {
                    result.Add(element);
                }
    
                return result;
            }
