        //Method to compare two list of string
        private List<string> Contains(List<string> list1, List<string> list2)
        {
            List<string> result = new List<string>();
            result.AddRange(list1.Except(list2, StringComparer.OrdinalIgnoreCase));
            result.AddRange(list2.Except(list1, StringComparer.OrdinalIgnoreCase));
            return result;
        }
