        private static void SetImmediateExpiryOnResponse(HttpResponse response)
        {
            response.Cache.SetAllowResponseInBrowserHistory(false);
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            response.Cache.SetNoStore();
            response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            response.Expires = -1;
            response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            response.CacheControl = "no-cache";
        }
