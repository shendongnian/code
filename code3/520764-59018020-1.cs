        public void RefreshContext(Item selectedItem)
        {
            commentColors.ForEach(si => { 
                if (selectedItem.ObjectId == Convert.ToInt32(si.Tag))
                {
                    si.Source = new BitmapImage(new Uri(selectedItem.Image, UriKind.Relative));
                    return;
                }
            });
        }
