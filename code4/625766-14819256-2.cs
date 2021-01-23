    void service_GetAllPositionsCompleted(object sender, 
                PositionServiceReference.GetAllPositionsCompletedEventArgs e)
    {
        //var lst = e.Result as IEnumerable<it_positions>; <-- This gave error
        var lst = e.Result; // <-- This worked fine
        var ary = lst.ToArray();
        //go do fun stuff with the array
        dgEmployee.ItemsSource = e.Result;
    
    }
