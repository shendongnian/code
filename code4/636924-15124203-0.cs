    private void BotaoSave_Click(object sender, RoutedEventArgs e)
            {
                SalvarTransaction();
                
                Grid gridParent = this.Parent as Grid;
    
                Popup parent = gridParent.Parent as Popup;
                if (parent != null)
                {
                    parent.IsOpen = false;
                }
            }
