    string source = "your html tag here";
    string href = Regex.Match(source, "href=\".*\"").Value.Replace("\"", "").Replace("href=", "");
    string url;
    string toReplace;
    bool tryToAppend = true;
                
    if(href.Contains("'"))
    {
        //if the href contains something else in quotes then its probably javascript
        //only capture something in quotes if it has a . (assume this means a url)
        url = Regex.Match(href, @"'.*\..*'").Value.Replace("'", "");
    
        //if we didnt find something in javascript with a . then abort
        if (url.Length == 0) 
        {
            tryToAppend = false;
        }
        toReplace = url;
    }
    else
    {
        url = href;
        toReplace = url;
    }
    
    if (tryToAppend)
    {
        if (url.Contains("?"))
        {
            url += "&append=1";
        }
        else
        {
            url += "?append=1";
        }
    
        source = source.Replace(toReplace, url);
    }
