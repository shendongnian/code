        var itemsSource = PGIPortfolio.ItemsSource as IEnumerable;
        if (itemsSource != null)
        {
            foreach (var item in itemsSource)
            {
                var row = PGIPortfolio.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null) 
                {
                   .....
                }
 
            }
        }
