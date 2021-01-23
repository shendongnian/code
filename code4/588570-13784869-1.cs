    foreach (PostEntry post in posts)
    {
        System.Diagnostics.Debug.WriteLine("loop starts");
        System.Diagnostics.Debug.WriteLine("id: " + post.Id);
        System.Diagnostics.Debug.WriteLine("title: " + post.Title);
        System.Diagnostics.Debug.WriteLine("body: " + post.Body);
        System.Diagnostics.Debug.WriteLine("loop ends");
        System.Diagnostics.Debugger.Break();
    }
