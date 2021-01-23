        List<int> indices = new List<int>();
        int currentCategory = -1;
        for (int i = 0; i < numbers.Count; i++)
        {
            int newCat = DetermineCategory(numbers[i]);
            if (newCat != currentCategory)
            {
                indices.Add(i);
                currentCategory = newCat;
            }
        }
        List<List<double>> collections = new List<List<double>>(indices.Count);
        for (int i = 1; i < indices.Count; ++i)
            collections.Add(new List<double>(
                numbers.Skip(indices[i - 1]).Take(indices[i] - indices[i - 1])));
