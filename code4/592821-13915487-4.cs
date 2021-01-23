            //set language if required...
            if (User.Identity.IsAuthenticated)
            {
                Entities.MembershipUserFull user = Services.MembershipUserManager.GetMembershipUserFull(HttpContext.Current.User.Identity.Name);
                if (user != null && user.LanguageId != null)
                {
                    GP.Solutions.Entities.Language language = Services.LanguageManager.GetLanguage((int)user.LanguageId);
                    if (Thread.CurrentThread.CurrentUICulture.Name != language.Code)
                    {
                        ChangeLanguage(language.Code, this);
                    }
                }
            }
