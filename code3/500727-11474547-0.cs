    string innerHtml = webbrowser.Document.GetElementById(something).InnerHtml;
    double value;
    
    if(Double.TryParse(innerHtml, out value))
    {
        // value is now populated
    };
