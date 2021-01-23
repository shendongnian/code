    // Create an enumerable of all IDs of Facebook providers from the users list
    var facebookIds = users
        // Exclude all users with a null EProviders list
        .Where(u => u.EProviders != null)
        // For each user, select all EProviders with type == facebook
        // and use SelectMany to flatten them into a single enumerable
        .SelectMany(u => u.EProviders.Where(p => p.type == EProvider.EnumType.facebook));
    // Use Join to find all facebooks whose IDs also exist in the facebookIds set constructed above
    var facebooksWithUsers = facebooks.Join(facebookIds, f => f.id, p => p.id, (f, p) => f);
    // Use Except to find the opposite subset
    var facebooksWithoutUsers = facebooks.Except(facebooksWithUsers);
    // Write the contents of the two sets to the console
    Console.WriteLine("facebooksWithUsers:");
    foreach (var fb in facebooksWithUsers)
    {
        Console.WriteLine(fb.id);
    }
    Console.WriteLine();
    Console.WriteLine("facebooksWithoutUsers:");
    foreach (var fb in facebooksWithoutUsers)
    {
        Console.WriteLine(fb.id);
    }
