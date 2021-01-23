    public HtmlNode GetNode(string text)
            {
    
                if (text.StartsWith("<")) //get the type of the element (a, p, div etc..)
                {
                    string type = "";
                    for (int i = 1; i < text.Length; i++)
                    {
                        if (text[i] == ' ')
                        {
                            type = text.Substring(1, i - 1);
                            break;
                        }
                    }
    
                    try //check to see if there are any nodes of your HTMLElement type that have an OuterHtml equal to the HtmlElement Outer HTML. If a node exist, than that's the node we want to use
                    {
                        HtmlNode n = doc.DocumentNode.SelectNodes("//" + type).Where(x => x.OuterHtml == text).First();
                        return n;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Cannot find the HTML element in the HTML Page");
                    }
                }
                else
                {
                    throw new Exception("Invalid HTML Element supplied. The selected HTML element must start with <");
                }
            }
