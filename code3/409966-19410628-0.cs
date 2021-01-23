            var store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var certificates = store.Certificates;
            X509Certificate2 match = null;
            foreach(var item in certificates)
            {
                if (item.SerialNumber != null && item.SerialNumber.Equals(serial, StringComparison.InvariantCultureIgnoreCase))
                {
                    match = item;
                    break;
                }
            }
