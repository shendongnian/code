                User user = (User)Context.Session[SessionKeys.CURRENT_USER];
                if (user == null)
                {
                    lock (_lock)
                    {
                        user = (User)Context.Session[SessionKeys.CURRENT_USER];
                        if (user == null)
                        {
                            user = _userBusiness.Find(CurrentUserId);
                            Context.Session[SessionKeys.CURRENT_USER] = user;
                        }
                    }
                }
