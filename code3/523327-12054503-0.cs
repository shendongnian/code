        public static Profile GetProfile() {
            Profile profile = null;
            if (HttpContext.Current.User.Identity.IsAuthenticated) {
                var user = Membership.Provider.GetUser(HttpContext.Current.User.Identity.Name, false);
                if (user != null) {
                    // an AD user who is already authed
                    profile = ReferralsData.GetProfilesByProviderKey(user.UserName) ?? new Profile();
                    profile.UserAccount = user;
                }
            }
            return profile;
        }
