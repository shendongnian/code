    using (var pc = new PrincipalContext(ContextType.Domain))
                {
                    using (var up = new UserPrincipal(pc))
                    {
                        up.SamAccountName = textboxUsername.Text; // Username
                        up.EmailAddress = textboxEmail.Text; // Email
                        up.SetPassword(textboxPassword.Text); // Password
                        up.Enabled = true;
                        up.ExpirePasswordNow();
                        up.Save();
                    }
                }
