    public void Sorting(ListBox lst, String order) {
                     if (order.Equals("A-Z"))
                    {
                        if (lst.Items.Count > 1)
                        {
                            bool swapped;
                            do
                            {
                                int counter = lst.Items.Count - 1;
                                swapped = false;
        
                                while (counter > 0)
                                {
                                    // Compare the items 
                                    if (lst.Items[counter].ToString().CompareTo(lst.Items[counter -
        1].ToString()) < 0)
                                    {
                                        // Swap the items.
                                        object temp = lst.Items[counter];
                                        lst.Items[counter] = lst.Items[counter - 1];
                                        lst.Items[counter - 1] = temp;
                                        swapped = true;
                                    }
                                    // Decrement the counter.
                                    counter -= 1;
                                }
                            }
                            while ((swapped == true));
                        }
                    }
                    if (order.Equals("Z-A")) {
                        if (lst.Items.Count > 1)
                        {
                            bool swapped;
                            do
                            {
                                int counter = lst.Items.Count - 1;
                                swapped = false;
        
                                while (counter > 0)
                                {
                                    // Compare the items 
                                    if (lst.Items[counter].ToString().CompareTo(lst.Items[counter -
        1].ToString()) > 0)
                                    {
                                        // Swap the items.
                                        object temp = lst.Items[counter];
                                        lst.Items[counter] = lst.Items[counter - 1];
                                        lst.Items[counter - 1] = temp;
                                        swapped = true;
                                    }
                                    // Decrement the counter.
                                    counter -= 1;
                                }
                            }
                            while ((swapped == true));
                        }
                    }
                    
                }
