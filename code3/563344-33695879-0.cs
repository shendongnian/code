    var userProfile = db.UserProfiles.First(x => x.UserId == userId);
                    var passwords = (userProfile.UserPasswordHistory
                                              .OrderByDescending(x => x.PasswordVersion)
                                              .Take(_configuration.PasswordCountBeforeReuseAllowed))
                                              .Select(x => x.Password);
    
    return passwords.Any(previousPassword => Crypto.VerifyHashedPassword(previousPassword, password));
