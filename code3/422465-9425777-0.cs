        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ContactUs(DatabaseModelExtensions.ContactRequest model) // Pass          model of which I am submitting a form against to retrieve data inside this HTTPPost Controller
        {
            // Create database object to map extension class to it.
            ContactRequest NewEntry = new ContactRequest();
            if (ModelState.IsValid)
            {
                // Map database object to the model passed and then insert.
                NewEntry.Name = model.Name;
                NewEntry.Email = model.Email;
                NewEntry.Message = model.Message;
                NewEntry.Timestamp = System.DateTime.Now;
                // Insert new entry into database for historical tracking
                NewEntry.Insert();
                
                // Clear modelstate (clearing form fields)
                // ModelState.Clear(); -- Does not work with an Ajax call - requires postback.
                // Email user about their contact request and also send admins a summary of the contact request.
                // Create new UserMailer Object so that we can invoke this class and work with it's functions/properties.
                var Mailer = new UserMailer();
                // Instantiated the 'msg' variable that will allow for us to invoke Mailer.ContactSubmission(), this function passes a series of parameters so that we can reference them inside
                // our UserMailer.cs class which then gets passed to a mail template called ContactSubmission.cshtml under the Views -> UserMailer folder
                var msg = Mailer.ContactSubmission(firstName: model.Name, email: model.Email, telephone: model.Telephone);
                // Same as above except we will be sending out the management notification.
                var msg1 = Mailer.AdminContactSubmission(firstName: model.Name, email: model.Email, datetime: System.DateTime.Now, message: model.Message, telephone: model.Telephone);
               
                // Invoke the .Send() extended function that will actually execute everything to send an SMTP mail Request.
                msg1.Send();
                msg.Send();
                
                // Return our content back to the page asynchronously also create a quick snippet of js to slide the message up after a few seconds.               
                return Content(new MvcHtmlString(@"
                                        <div id='sendmessage'>
                                            Your message has been sent, Thank you!
			                            </div>
                                        <script type='text/javascript'>
				                           setTimeout(function () { jQuery('#results').slideUp('fast') }, 3000);
                                        </script>").ToString());
            }
                // Return our Error back to the page asynchronously.
            return Content(new MvcHtmlString(@"
                                        <div id='errormessage'>
                                            An error has occured, please try again in a few moments!
			                            </div>
                                        <script type='text/javascript'>
				                           setTimeout(function () { jQuery('#results').slideUp('fast') }, 3000);
                                        </script>").ToString());
        }
