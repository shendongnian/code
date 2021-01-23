     HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("button");
     foreach (HtmlElement elem in elems)
     {
        String name = elem.GetAttribute("name");
        //identify the button by matching the name
        if (name != null && name.Length != 0 && name.equals("myButton"))
        {
           //write your code here
        }
      }
