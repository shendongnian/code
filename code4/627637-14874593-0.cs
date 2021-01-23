            int Id = 0;
            provider = new tbl_Provider
            {
                provider_Name = txt_ProviderName.Text,
                ...
            };
            // Insert
            _db.tbl_Providers.InsertOnSubmit(provider);
            // Save
            _db.SubmitChanges();
            Id = provider.ProviderId;
