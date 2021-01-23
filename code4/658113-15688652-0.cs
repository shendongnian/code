        public int AccountEmailId { get; set; }
        public string AccountEmailDescription { get; set; }
    }
    
    **Step 2:
    
    In your rendering Model like**
   
     public class UserBaseViewModel
        {    
            
                   
                    public IEnumerable<SelectListItem>  AccountEmail { get; set; }
                    public string AccountEmail { get; set; }
        }
    
    **Step 3:**
    
    
   
     [HttpGet]
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
