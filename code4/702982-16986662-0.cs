    void YourPage_Loaded(object sender, RoutedEventArgs e)
            {         
                m_Map.ZoomLevel = 11;          
                m_Map.LayoutUpdated += m_Map_LayoutUpdated; 
            }
    
            void m_Map_LayoutUpdated(object sender, EventArgs e)
            {
                if (!isRemoved) 
                {
                    RemoveOverlayTextBlock();
                }
            }
    
            void  RemoveOverlayTextBlock()
            {             
                var textBlock = m_Map.DescendantsAndSelf.OfType<TextBlock>()
                               .SingleOrDefault(d => d.Text.Contains("Invalid Credentials") ||
                                                     d.Text.Contains("Unable to contact Server"));
                if (textBlock != null)
                {
                    var parentBorder = textBlock.Parent as Border;
                    if (parentBorder != null)
                    {
                        parentBorder.Visibility = Visibility.Collapsed;
                    }
                    isRemoved = true;   
                }
           }
