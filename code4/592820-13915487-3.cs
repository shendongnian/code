        internal static void ChangeLanguage(string languageCode, System.Web.UI.Page page)
        {
            CultureInfo ci = new CultureInfo(languageCode);
            page.Session[cLanguageSessionKey] = ci;
            //save to user profile is required (just a sample)...
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Entities.MembershipUserFull user = Services.MembershipUserManager.GetMembershipUserFull(HttpContext.Current.User.Identity.Name);
                user.LanguageId = Services.LanguageManager.GetLanguageIdFromLanguageCode(languageCode);
                //save profile... 
                user.SaveProfile();
            }
            //reload page. New culture will take efect...
            page.Response.Redirect(page.Request.Url.AbsoluteUri);
        }
