        public HtmlElement selectHtmlNode(string xPath, HtmlElement htmlElement)
        {
            string currentNode;
            int indexOfElement;
            //get string representation of current Tag.
            if (xPath.Substring(1,xPath.Length-2).Contains('/'))
                currentNode = xPath.Substring(1, xPath.IndexOf('/', 1) - 1);
            else
                currentNode = xPath.Substring(1, xPath.Length-1);
            //gets the depth of current xPath
            int numOfOccurence = Regex.Matches(xPath, "/").Count;
            
            //gets the children's index
            int.TryParse(Regex.Match(currentNode, @"\d+").Value, out indexOfElement);
            //if i have to select nth-child ex: /tr[4]
            if (indexOfElement > 1)
            {
                currentNode = currentNode.Substring(0, xPath.IndexOf('[') - 1);
                //the tag that i want to get
                if (numOfOccurence == 1 || numOfOccurence == 0)
                {
                    return htmlElement.Children[indexOfElement - 1];
                }
                //still has some children tags
                if (numOfOccurence > 1)
                {
                    int i = 1;
                    //select nth-child
                    foreach (HtmlElement tempElement in htmlElement.Children)
                    {
                        if (tempElement.TagName.ToLower() == currentNode && i == indexOfElement)
                        {
                            return selectHtmlNode(xPath.Substring(xPath.IndexOf('/', 1)), tempElement);
                        }
                        else if (tempElement.TagName.ToLower() == currentNode && i < indexOfElement)
                        {
                            i++;
                        }
                    }
                }
            }
            else
            {
                if (numOfOccurence == 1 || numOfOccurence == 0)
                {
                    return htmlElement.FirstChild;
                }
                if (numOfOccurence > 1)
                {
                    foreach (HtmlElement tempElement in htmlElement.Children)
                    {
                        if (tempElement.TagName.ToLower() == currentNode)
                        {
                            return selectHtmlNode(xPath.Substring(xPath.IndexOf('/', 1)), tempElement);
                        }
                    }
                }
            }
            return null;
        }
