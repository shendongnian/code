        var parameters = new [] { parameter1, parameter2, /*...*/ }
        reservations = reservations
            .Where(r => 
                parameters.Any(p => r.GuestFirstName.Contains(p)
                                    || r.GuestLastName.Contains(p)));
