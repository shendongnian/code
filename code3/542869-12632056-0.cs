                     HtmlElement ele = webBrowser1.Document.GetElementById("usernameID"); if (ele != null)
                ele.InnerText = "username"; 
            ele = webBrowser1.Document.GetElementById("passwordID"); if (ele != null)
                ele.InnerText = "password";
            ele = webBrowser1.Document.GetElementById("goButtonID"); if (ele != null)
                ele.InvokeMember("click");
