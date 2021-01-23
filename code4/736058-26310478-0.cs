                    for(int n=0;n < node.Children.Count;n++)
                    {
                        if(node.Children[n].Title != "Products")
                        {         
                            node.Children.RemoveAt(n);          
                             @Html.DisplayFor(m => node.Children)
                        } 
                    }
               }          
            }
        </li>
    }
