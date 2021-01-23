      public static LicenseInformation licenseInformation;
        
        if (!App.licenseInformation.ProductLicenses["productid"].IsActive)
                 {
                        try
                        {
                            // The user doesn't own this feature, so 
                            // show the purchase dialog.
                            await CurrentApp.RequestProductPurchaseAsync("productid", false);
                            // the in-app purchase was successful
                        }
                        catch (Exception)
                        {
                            // The in-app purchase was not completed because 
                            // an error occurred.
                        }
                    }
                    else
                    {
        
                        // The user already owns this feature.
                    }
                }
