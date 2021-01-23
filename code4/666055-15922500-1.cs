    private static List<float> Test(float input)
        {
            var list = new List<float>();
            while (input> 0)
            {
                list.Add(input);
                input--;
            }
            return list;
        }
