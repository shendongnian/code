    Dispatcher.Invoke(DispatcherPriority.Normal, ignore => 
        {
            dcrt.DrawText(new FormattedText(index.ToString(), new System.Globalization.CultureInfo("en-us"),
           System.Windows.FlowDirection.LeftToRight,
          new Typeface("Verdana"), 16, System.Windows.Media.Brushes.OrangeRed),
          new System.Windows.Point(Shoudery_lefty.X+50,Shoudery_lefty.Y+50));
        });
