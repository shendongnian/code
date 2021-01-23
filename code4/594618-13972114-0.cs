                    await CurrentApp.RequestProductPurchaseAsync("PremiumFeatures", false);
                    if (licenseInformation.ProductLicenses["PremiumFeatures"].IsActive)
                    {
                        //Success in purchase use ur own code block
                    }
                    else
                    {
                        //error in purchase use your own code block
                    }
