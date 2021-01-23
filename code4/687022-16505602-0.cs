        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
               int j = 0;
               foreach (Image child in WrapPanelPictures.Children)
               {
                    // int j = 0;
                    if (child.Source == MainPic.Source)
                    {
                        MainPic.Source = WrapPanelPictures.Children[j + 1].Source;
                        break;
                    }
                    j++;
                }
            }
        }
