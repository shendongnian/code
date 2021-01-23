    private static List<float> Test(float input)
        {
            var list = new List<float>();
            var temp = input;
    
            while (temp > 0)
            {
                list.Add(temp);
                temp -= 1;
            }
            return list;
        }
