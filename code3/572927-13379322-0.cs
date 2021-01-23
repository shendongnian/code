    try
    {
        await CurrentAppProxy.RequestProductPurchaseAsync(PremiumName, false);
        // after closing the inApp purchase dialog, test, if it was bought
        if (licenseInformation.ProductLicenses[PremiumName].IsActive)
        {
            // set the local flag
            IsPremium = true;
            dialog = new MessageDialog(resourceLoader.GetString("ThanksForPremium"));
            await dialog.ShowAsync();
        }
        // else do not show anything
    }
    catch (Exception)
    {
        // failed buying the premium
        dialog = new MessageDialog(resourceLoader.GetString("ErrorBuyingPremium"));
        dialog.ShowAsync();
    }
