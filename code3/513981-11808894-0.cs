    UIGraphics.BeginImageContextWithOptions (new SizeF (size, size), false, 0);
    using (var c = UIGraphics.GetCurrentContext ()) {
       var context = CIContext.FromContext (c);
       ...
    }
    UIGraphics.EndImageContext ();
