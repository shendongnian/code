        if (Request.Content.IsMimeMultipartContent())
        {
            return Request.Content.ReadAsMultipartAsync(provider.Provider).ContinueWith(t => 
                        {
                            if (t.IsCanceled || t.IsFaulted)
                                return (object)new { success = false };
