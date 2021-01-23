                [HttppGet]
                public ActionResult SelectAccountEmail()
                {
                    var EmailAccounts = (from AccountEmail in db.UserBases select AccountEmail)
        
                   UserBase userbaseViewModel = new UserBase
                    {
                        AccountEmail = EmailAccounts.Select(x => new SelectListItem
                      {
                          Text = x.AccountEmailDescription,
                          Value = Convert.ToString(x.AccountEmailId)
                      }).ToList()
        
                    };
                    return View(userbaseViewModel);
                }
