    // Given:
    //   var xdoc = XDocument.Load(...);
    //   string applianceName = "Toaster";
    // Find all appliance nodes who have a sub-element <Name> matching the appliance
    var app = xdoc.Root
                  .Descendants("Appliance")
                  .SingleOrDefault(e => (string)e.Element("Name") == applianceName);
    // If we've found one and it matches, make a change
    if (app != null)
    {
        if (((string)app.Element("Model")).StartsWith("B8d-k30"))
        {
            app.Element("Model").Value = "B8d-k30 Mark II";
        }
    }
    xdoc.Save(@"output.xml"); // save changes back to the document
