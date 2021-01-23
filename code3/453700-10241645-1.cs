       public Node FindNodeRecursively(Node parentNode, string keyword)
            {
                if(parentNode.getData() == keyword)
                {
                    return parentNode;
                }
                else
                {
                    if(parentNode.Children != null)
                    {
                        foreach(var node in parentNode.Children)
                        {
                            var temp = FindNodeRecursively(node, keyword);
                            if(temp != null)
                                return temp;
                        }
                    }
                    return null;
                }
            }
