        Using Systems.Net.Mail;
    // POST: /Account/Register
    //Here's a simple Mail(MVC4)
      
            public async Task<ActionResult> Register(RegisterViewModel model)
            {
                Mail email= new Mail();
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        email.to = new MailAddress(model.Email);
                        email.body = "Hello " + model.Firstname + " your account has been created <br/> Username: " + model.UserName + " <br/>Password: " + model.Password.ToString() + " <br/> change it on first loggin";
                        ViewBag.Feed = email.reg();
                        
    
                        await SignInAsync(user, isPersistent: false);
                        
                        
                         return RedirectToAction("Index", "Home");
    
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
    
                // If we got this far, something failed, redisplay form
                return View(model);
            }
    
       
    
    
    //Business Logic(this Is you Email Class)
    
    
    
    
    Using Systems.Net.Mail;
    
    
     public class Mail
    
        {
            public MailAddress to { get; set; }
            public MailAddress from { get; set; }
            public string sub { get; set; }
            public string body { get; set; }
    
    
    
    
            public string reg()
            {
                string feed = "Registration Successful";
                var m = new System.Net.Mail.MailMessage()
                {
                    Subject = "",
                    Body = body,
                    IsBodyHtml = true
                };
                m.From = new MailAddress("Mxolisi@gmail.com  ", "Administrator");
                m.To.Add(to);
                SmtpClient smtp = new SmtpClient
                {
                    Host = "pod51014.outlook.com",
                    //Host = "smtp-mail.outlook.com",
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("Mxolisi@gmail.com ", " Dut324232"),
                    EnableSsl = true
                };
    
                try
                {
                    smtp.Send(m);
                    // feed = "";
                }
                catch (Exception e)
                {
    
                }
    
                return feed;
    
            }
            public string fogot()
            {
                string feedback = "";
    
                var m = new System.Net.Mail.MailMessage()
                {
                    Subject = "Reset Password PIN",
                    Body = body,
                    IsBodyHtml = true
                };
                m.From = new MailAddress("Mxolisi@gmail.com ", "Administrator");
                m.To.Add(to);
                SmtpClient smtp = new SmtpClient
                {
                    Host = "pod51014.outlook.com",
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("Mxolisi@gmail.com ", "Dut324232"),
                    EnableSsl = true
                };
    
                try
                {
                    smtp.Send(m);
                    feedback = "Check your email for PIN";
                }
                catch (Exception e)
                {
                    feedback = "Message not sent" + e.Message;
                }
                return feedback;
    
            }
    
        }
    }
