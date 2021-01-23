    RxProperty = Observable.FromEvent<TextChangedEventHandler, TextChangedEventArgs>(
            h => new TextChangedEventHandler(h),
            h => AssociatedObject.TextChanged += h,
            h => AssociatedObject.TextChanged -= h)
             
            .Select(t => ((TextBox)t.Sender).Text)
 
            .Throttle(TimeSpan.FromMilliseconds(400))
 
            .SubscribeOnDispatcher()
            .Take(10)
            .TakeUntil(AssociatedObject.TextChanged );
