    private async void history_Click(object sender, RoutedEventArgs e)
    {
    bool OK = true;
    // Get the license info
    // The next line is commented out for testing.
    // licenseInformation = CurrentApp.LicenseInformation;
    // The next line is commented out for production/release.       
    LicenseInformation licenseInformation = CurrentAppSimulator.LicenseInformation;
    if (!licenseInformation.ProductLicenses["PremiumFeatures"].IsActive)
    {
        try
        {
            // The customer doesn't own this feature, so 
            // show the purchase dialog.
            await CurrentAppSimulator.RequestProductPurchaseAsync("PremiumFeatures", false);
                    if (licenseInformation.ProductLicenses["PremiumFeatures"].IsActive)
                    {
                        // the in-app purchase was successful
                         OK = true;
                        //Success in purchase use ur own code block
                    }
                    else
                    {
                         OK = false;
                        //error in purchase use your own code block
                    }
            
        }
        catch (Exception)
        {
            // The in-app purchase was not completed because 
            // an error occurred.
            OK = false;
        }
    }
    else
    {
        // The customer already owns this feature.
        OK = true;
    }
    if (OK)
    {
        Frame.Navigate(typeof(HistoryPage));
    }
}
