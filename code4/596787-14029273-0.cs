    if(numberOfBookings >= numberOfAvailableSeats)
    {
    
    if (e.Row.Cells[0].HasControls())
            {
                var button = e.Row.Cells[0].Controls[1] as LinkButton;
    
                button.Enabled = false;
    
            }
    }
