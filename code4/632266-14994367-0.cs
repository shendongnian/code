     resultsbox.ItemsSource = results;
        if (results.Count == 0)
        {
            foreach (ele item in eles)
            {
                if (!results.Contains(item.nameElement))
                {
                    results.Add(item.nameElement);
                }
            }
        }
