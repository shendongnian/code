     foreach (var child in ContentPanel.Children)
            {
                if (child is Border)
                {
                    var borderName = (child as Border).Name;
                    
                    // if you wana get the image inside border, then do this.
                    var getBorderChlid = (item as Border).Child;
                    if (getBorderChlid is Image)
                    {
                        var getImgName = (getBorderChlid as Image).Name;
                    }
                }
            }
