    private void button1_Click(object sender, RoutedEventArgs e)
    {
      var sb = new Storyboard();
      var db = CreateDoubleAnimation(30, 100,
             button1, Button.HeightProperty, TimeSpan.FromMilliseconds(1000));
      sb.Children.Add(db);
      sb.Begin();
    }
    private static DoubleAnimation CreateDoubleAnimation(double from, double to, 
          DependencyObject target, object propertyPath, TimeSpan duration)
    {
      var db = new DoubleAnimation();
      db.To = to;
      db.From = from;
      db.Duration = duration;
      Storyboard.SetTarget(db, target);
      Storyboard.SetTargetProperty(db, new PropertyPath(propertyPath));
      return db;
    }
