    //Create a provider collection to set various processing properties
    System.Collections.Generic.Dictionary<string, object> providers = new System.Collections.Generic.Dictionary<string, object>();
    //Set the image base. This will be prepended to the SRC so make sure to include a trailing slash
    providers.Add(HTMLWorker.IMG_BASEURL, @"C:\users\x\documents\visualstudio2010\projects\myproject\");
    var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), null, providers);
