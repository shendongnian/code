     var sb = new Storyboard();
                var ta = new ThicknessAnimation();
                ta.BeginTime = new TimeSpan(0);
                ta.SetValue(Storyboard.TargetNameProperty, "label");
                Storyboard.SetTargetProperty(ta, new PropertyPath(MarginProperty));
    
                ta.From = new Thickness(300, 30, 0, 0);
                ta.To = new Thickness(0, 30, 0, 0);
                ta.Duration = new Duration(TimeSpan.FromSeconds(3));
    
                sb.Children.Add(ta);
                sb.Begin(this);
