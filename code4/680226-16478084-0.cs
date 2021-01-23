    using (wic = WindowsIdentity.Impersonate(admin_token))
    {
            // these operations are executed as impersonated user
            File.Copy(@"", @"", true);
            MessageBox.Show("Copy Succeeded");
    }
