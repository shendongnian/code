        private void Panorama_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1) return;
            if (!(e.AddedItems[0] is PanoramaItem)) return;
            PanoramaItem selectedItem = (PanoramaItem)e.AddedItems[0];
            
            string strTag = (string)selectedItem.Tag;
            if (strTag.Equals("places"))
                // Do places stuff
            else if (strTag.Equals("routes"))
                // Do routes stuff
         }
