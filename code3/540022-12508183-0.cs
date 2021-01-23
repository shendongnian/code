                var copyToUser = this.GetUser(copyToUserId);
                List<UserApplicationRole> userApplicationRoles = new List<UserApplicationRole>();
                int startingId = Convert.ToInt32(isignonContext.UserApplicationRoles.OrderByDescending(u => u.UserApplicationRoleId).FirstOrDefault().UserApplicationRoleId) + 1;
                foreach (var u in userApplicationRolesToAdd)
                {
                    UserApplicationRole userApplicationRole = new UserApplicationRole
                    {
                        UserApplicationRoleId = startingId,
                        UserID = copyToUser.UserId,
                        UserGroupId = copyToUser.ParentId.Value,
                        ApplicationRoleId = u.ApplicationRoleId,
                        ExpiryDate = u.ExpiryDate,
                        IsEnabled = u.IsEnabled
                    };
                    userApplicationRoles.Add(userApplicationRole);
                    startingId++;
                }     
