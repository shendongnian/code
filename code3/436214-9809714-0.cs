    flicker = new Flickr(key, secret);
            FlickrNet.Cache.CacheDisabled = true;
            
            string flickrUrl = flicker.AuthCalcWebUrl(AuthLevel.Write);
            Response.Redirect(flickrUrl);
            //(the user will be ask to accept making changes on his account once if every thing is working)
