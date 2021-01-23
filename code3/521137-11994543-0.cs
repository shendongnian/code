    using (var client = new WebClient())
    using (var stream = client.OpenRead("..."))
    using (var file = File.OpenWrite("..."))
    {
        stream.CopyTo(file);
    }
