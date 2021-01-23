                switch (Common.ApplicationLanguage)
                {
                    case Common.Languages.Arabic:
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar-EG");
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-EG");
                        break;
                    case Common.Languages.English:
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                        break;
                    default:
                        break;
                }
