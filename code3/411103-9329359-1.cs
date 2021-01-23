    VMware.Vim.LicenseManager lic_manager = (VMware.Vim.LicenseManager)client.GetView(client.ServiceContent.LicenseManager, null);
    LicenseManagerLicenseInfo[] lic_found = lic_manager.Licenses;
    foreach (LicenseManagerLicenseInfo lic in lic_found)
    {
        string test = lic.Name.ToString();
        string test2 = lic.LicenseKey.ToString();
    }
