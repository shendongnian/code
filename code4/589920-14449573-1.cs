    if (model.AccountType == AccountType.Tenant)
                    {
                        try
                        {
                            Roles.AddUserToRole(model.UserName, "Tenant");
                        }
                        catch (Exception e)
                        {
                            ModelState.AddModelError("Unable to add user to role", e);
                        }
                    }
