    tb.TextChanged =+ (sender, args ) =>
    {
        if(! MeetsMyExpectations(tb.Text) )
            Dispatcher.BeginInvoke(new Action(() => tb.Undo()));
    }
 
