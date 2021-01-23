     var activity = new Activities()
            {
                Time = DateTime.Now,
                Message = message
            };
     activities.Add(activity);
 
     ActivityList.ItemsSource = activities;
     ActivityList.ScrollIntoView(activity);
