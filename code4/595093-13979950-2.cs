    var result = MI.GetTheatersAndMovies(txtZip.Text, rad);
    StringBuilder sb  = new StringBuilder();
    foreach(var item in result)
    {
         sb.Append(string.Format("Theater Name: {0}",item.Name));
         sb.Append(string.Format("Address: {0}",item.Address));
         foreach (var movie in item.Movies)
         {
              sb.Append(string.Format("Movie: {0}",movie.Name));
              sb.Append(string.Format("Rating: {0}",movie.Rating));
         }
    }
    txtResults.Text = sb.ToString();
