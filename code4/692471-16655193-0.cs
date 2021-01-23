    public void OpenTabForm(Page oPage)
            {
                try
                {
                    Frame oFrame = new Frame();
                    oFrame.Content = oPage;
    
                    TabItem myItem = new TabItem();
    
                    myItem.Header = oPage.Name; //give the header text
                    myItem.Content = oFrame;
    
                    tbtabMain.Items.Add(myItem);
    
                    tbtabMain.SelectedItem = myItem;
                }
                catch (Exception ex)
                {
                    //handle error
                }
            }
