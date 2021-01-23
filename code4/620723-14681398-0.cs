    webBrowser1.Document.GetElementById("navbar_username").InnerText ="Tester";
    webBrowser1.Document.GetElementById("navbar_password").InnerText = "xxxxxxxxxxx";
     
    foreach (HtmlElement HtmlElement1 in webBrowser1.Document.Body.All)
        {
        if (HtmlElement1.GetAttribute("value") == "Log in")
            {
            HtmlElement1.InvokeMember("click");
            break;
            }
        }
