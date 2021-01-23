       if (String.IsNullOrEmpty(searchTxt.Text) == false)
        {
          query = query.Where(c => c.name.ToLower().Contains(searchTxt.Text.ToLower())).ToList();
        }
    
        if (cityCB.SelectedIndex > -1)
        {
           query =  query.Where(c => c.city.ToLower().Equals(cityCB.Text.ToLower())).ToList();
        }
