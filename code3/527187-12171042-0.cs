     public static void ShowToast()
        {
            try
            {
                string langKey = CacheManager.getInstance().getDataFromConfigFile(CacheManager.APP_CURRENT_LANGUAGE);
                string flag = CacheManager.getInstance().getDataFromConfigFile(CacheManager.APP_UPGRADE_STATUS);
                string catalogUpdateFlag = CacheManager.getInstance().getDataFromConfigFile(CacheManager.APP_CATALOG_UPGRADE_STATUS);
                CultureInfo ci;
                if ((null == langKey) || (langKey.Equals(Utils.LANGUAGE_EN)))
                {
                    ci = new CultureInfo("en-US");
                }
                else
                {
                    ci = new CultureInfo("fr-FR");
                }
                AppResources.Culture = ci;
                if (!Utils.isNullString(flag))
                {
                    var toast = new ShellToast
                    {
                        Title = AppResources.APP_NAME,
                        Content = getMessageStatus(flag),
                        NavigationUri = new System.Uri("/MainPage.xaml", System.UriKind.Relative)
                    };
                    Logger.log(TAG, ":ShowToast():MessageToUser" + AppResources.APP_NAME + getMessageStatus(flag));
                    toast.Show();
                }
                if (!Utils.isNullString(catalogUpdateFlag))
                {
                    var toast = new ShellToast
                    {
                        Title = AppResources.APP_NAME,
                        Content = getMessageStatus(catalogUpdateFlag),
                        NavigationUri = new System.Uri("/MainPage.xaml", System.UriKind.Relative)
                    };
                    Logger.log(TAG, ":ShowToast():MessageToUser" + AppResources.APP_NAME + getMessageStatus(catalogUpdateFlag));
                    toast.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.log(TAG, "Exception in ShowToast: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
        private static string getMessageStatus(string flagType)
        {
            //string flag = CacheManager.getInstance().getApplicationSettings(CacheManager.APP_UPGRADE_STATUS);
            string flag = CacheManager.getInstance().getDataFromConfigFile(CacheManager.APP_UPGRADE_STATUS);
            string catalogUpdateFlag = CacheManager.getInstance().getDataFromConfigFile(CacheManager.APP_CATALOG_UPGRADE_STATUS);
            if (flagType == flag)
            {
                if (flag.Equals(CacheManager.MAJOR_UPGRADE))
                {
                    return AppResources.APP_UPGRADE_CONFIRM;
                }
                else if (flag.Equals(CacheManager.MINOR_UPGRADE))
                {
                    return AppResources.APP_UPGRADE_MINOR_CONFIRM;
                }
            }
            else if (flagType == catalogUpdateFlag)
            {
                return AppResources.APP_CATALOG_CONFIRM;
            }
            return "";
        }
