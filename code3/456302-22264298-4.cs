        using (var manager = NewsManager.GetManager())
        {
            var newsItems = manager.GetNewsItems().Where(p => 
                p.Status == ContentLifecycleStatus.Live && p.Visible).ToList();
            // append items
            foreach (var item in newItems)
            {
                var location = SystemManager.GetContentLocationService().GetItemDefaultLocation(item);
                if (location != null)
                {
                    var fullUrl = location.ItemAbsoluteUrl;
                    // Then append to sitemap...                    
                }
            }
        }
