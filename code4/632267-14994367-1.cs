    results.Clear();
        foreach (ele item in eles)
        {
            if (item.nameElement.ToLower().Contains(searchbox.Text.ToLower()))
            {
                results.Add(item.nameElement);
            }
        }
    
    resultsbox.ItemsSource = results;
