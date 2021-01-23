    [HttpPost,ActionName("Mail")] // this Method allow to send a email
        public ActionResult MailConfirmed(int id, string messageBody)
        {
            Customer customer = db.Customers.Find(id);
            
            if(messageBody!=null)
            {
                System.Diagnostics.Debug.WriteLine(messageBody);
                SendMail(customer.Mail, customer.Name, messageBody);
                return RedirectToAction("Index");  
            }
            else
            {
                ModelState.AddModelError("", "Veuillez rentrer un message SVP"); 
            }
            return View(customer);
        }
