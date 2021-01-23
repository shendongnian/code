      private void btnSort_Click(object sender, RoutedEventArgs e)    
        {   
         ArrayList Sorting = new ArrayList();
                    if (!this.lstbxResults.Items.Contains(this.lstbxResults.Items))
                    {
                        foreach (var fSort in lstbxResults.Items)
                        {
                            Sorting.Add(fSort);
                        }
        
                        Sorting.Sort();
        
                        lstbxResults.Items.Clear();
        
                        foreach (var fSort in Sorting)
                        {
                            if (!this.lstbxResults.Items.Contains(fSort))
                            {
                                lstbxResults.Items.Add(fSort);
                            }
                            
                        }
                    }
        }
