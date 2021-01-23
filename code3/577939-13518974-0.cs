    public static void AddRepositionTransitionsUsingRenderTransform(this FrameworkElement control, bool x = true, bool y = true, CancellationToken lifetime = default(CancellationToken)) {
        if (control == null) throw new ArgumentNullException("control");
        var approachPeriod = TimeSpan.FromMilliseconds(100);
        // animate when positions change, to give a 'swooping' effect instead of teleporting
        var transform = new TranslateTransform();
        var oldPosition = May<Point>.NoValue;
        EventHandler updated = (sender, arg) => {
            // determine where the control has moved to
            var newPosition = control.ActualWidth == 0 || control.ActualHeight == 0 || control.Visibility != Visibility.Visible
                            ? May<Point>.NoValue
                            : control.TranslatePoint(new Point(-transform.X, -transform.Y), Application.Current.MainWindow);
            if (oldPosition == newPosition) return;
                
            // adjust the animation to initially cancel the change in position, and finish at the new final position after the approach period
            var dif = (from o in oldPosition
                        from n in newPosition
                        select new Point(n.X - o.X, n.Y - o.Y)
                        ).ElseDefault();
            if (x) transform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(transform.X - dif.X, 0, approachPeriod));
            if (y) transform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation(transform.Y - dif.Y, 0, approachPeriod));
            oldPosition = newPosition;
        };
        // register for events and replace transform, until lifetime ends
        var oldTransform = control.RenderTransform;
        control.RenderTransform = transform;
        control.LayoutUpdated += updated;
        lifetime.Register(() => {
            control.LayoutUpdated -= updated;
            control.RenderTransform = oldTransform;
        });
    }
