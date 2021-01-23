    var lastPage = pages.Elements().LastOrDefault(); // getting last page if any
    if (lastPage != null)
    {
        lastPage.Add(new XAttribute("foo", "bar")); // add new attribute
        lastPage.SetAttributeValue("name", "bbb"); // modify attribute
    }
