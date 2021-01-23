    public class UserMailer : MailerBase 	
	{
        RegisterService Service = new RegisterService();
        HttpContext Context;
		public UserMailer(HttpContext context)
		{
            Context = context;
			MasterName="_Layout";
		}
		
		public void ConfirmRegistration(Register model)
		{
            SendAsync(() =>
            {
                model.Conference = Service.Context.Conferences.Find(model.ConferenceID); // load conference bcs it fails to lazy load automatically.
                ViewData.Model = model;
                return Populate(x =>
                {
                    x.Subject = "You registered for " + model.Conference.Name + "!"; ;
                    x.ViewName = "Confirm";
                    x.To.Add(model.Email);
                });
            });
		}
        private void SendAsync(Func<MvcMailMessage> GetEmail)
        {
            Task.Factory.StartNew(() =>
            {
                System.Web.HttpContext.Current = Context;
                GetEmail().Send();
            });
        }
