        private static void Merge(XElement left, XElement right)
        {
            foreach (var node in right.Elements().ToList())
            {
                if (left.Element(node.Name.LocalName) == null)
                {
                    // Find correct Parent in Xml-File
                    if (xDoc1.Elements().Count(x => x.Name.LocalName.Equals(node.Name.LocalName)) <= 1)
                    {
                        if (node.HasElements)
                        {
                            left.Add(node);
                        }
                        else
                        {
                            if (node.Parent.Name.LocalName.Equals(left.Name.LocalName))
                            {
                                int hierachy = right.NodesBeforeSelf().Count(r => ((XElement)r).Name.LocalName.Equals(node.Parent.Name.LocalName));
                                if (hierachy == 0)
                                {
                                    left.Add(node);
                                }
                                else
                                {
                                    var xElements = xDoc1.Descendants().Where(x => ((XElement)x).Name.LocalName.Equals(node.Parent.Name.LocalName));
                                    try
                                    {
                                        xElements.ElementAt(hierachy).Add(node);
                                    }
                                    catch (Exception e)
                                    {
                                        throw new Exception(e.Message);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new NotImplementedException("> 1");
                    }
                    right.Element(node.Name.LocalName).Remove();
                }
            }
            if (left.HasElements == false && right.HasElements == false)
            {
                if (left.Name.LocalName.Equals(right.Name.LocalName))
                {
                    if (left.Parent != null && right.Parent != null)
                    {
                        if (left.Parent.Name.LocalName.Equals(right.Parent.Name.LocalName))
                        {
                            int hierachy = right.NodesBeforeSelf().Count(r => ((XElement)r).Name.LocalName.Equals(right.Parent.Name.LocalName));
                            if (hierachy == 0)
                            {
                                left.Parent.Add(right);
                            }
                            else
                            {
                                var xElements = xDoc1.Descendants().Where(x => ((XElement)x).Name.LocalName.Equals(right.Parent.Name.LocalName));
                                try
                                {
                                    xElements.ElementAt(hierachy).Add(right);
                                }
                                catch (Exception e)
                                {
                                    throw new Exception(e.Message);
                                }
                            }
                        }
                    }
                }
            }
            foreach (var x in right.Elements().Where(r => left.Element(r.Name.LocalName) != null))
            {
                Merge(left.Element(x.Name.LocalName), x);
            }
        }
