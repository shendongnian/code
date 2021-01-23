    //Load your document first.
    HtmlDocument mainDoc = new HtmlDocument();
    mainDoc.Load("foobar.html");
    
    //Select all the <li> nodes that are inside of an element with the id of "content"
    HtmlNodeCollection processMe = mainDoc.GetElementbyId("content")
                                          .SelectNodes("//li");
    //Iterate through each <li> node and print the inner text to the console
    foreach (HtmlNode listElements in processMe)
    {
        Console.WriteLine(listElements.InnerText);
    }
