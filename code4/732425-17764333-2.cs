    var emailUnchanged = !ItemsHaveChanged(...);
    var usernameUnchanged = !ItemsHaveChanged(...);
    if (emailUnchanged || usernameUnchanged) {
        // neither changed
        args.IsValid = false;
        ...
    }
