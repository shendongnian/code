    try{
        Registry.CurrentUser.OpenSubKey(@"PATH\TO\STUFF", true);
        // Have write permissions.
    }
    catch {
        // Do not have write permissions.
    }
