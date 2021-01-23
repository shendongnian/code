    var loginResult = TryLogin(..., ...);
    switch (loginResult.Result)
    {
        case Info.LoginSuccess:
            var customerId = loginResult.CustomerId;
            //do your duty
            break;
        case Info.NoMatchPasswordEmail:
            //Yell at them
            break;
        ...
    }
