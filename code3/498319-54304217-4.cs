    public class Mail
        {
            private static readonly IRazorEngineService RazorEngine;
    
            static Mail()
            {
                var config = new TemplateServiceConfiguration
                {
                    BaseTemplateType = typeof(CustomTemplateBase<>),
                    TemplateManager = new EmbeddedTemplateManager(typeof(Mail).Namespace + ".Templates"),
                    Namespaces = { "Add CurrentProjectName", "Add CurrentProjectName .Models" },
                    CachingProvider = new DefaultCachingProvider()
                };
                RazorEngine = RazorEngineService.Create(config);
            }
    
            public Mail(string templateName)
            {
                TemplateName = templateName;
                ViewBag = new DynamicViewBag();
            }
    
            public string TemplateName { get; set; }
    
            public object Model { get; set; }
    
            public DynamicViewBag ViewBag { get; set; }
    
            public string GenerateBody()
            {
                var layout = RazorEngine.RunCompile("_Layout", model: null);
                var body = RazorEngine.RunCompile(TemplateName, Model.GetType(), Model);
                return layout.Replace("{{BODY}}", body);
            }
    
            public MailMessage Send(Guid key, string to, string subject, string cc = null)
            {
                var email = new MailMessage()
                {
                    From = MailConfiguration.From,
                    Body = GenerateBody(),
                    IsBodyHtml = true,
                    Subject = subject,
                    BodyEncoding = Encoding.UTF8
                };
    
                email.Headers.Add("X-MC-Metadata", "{ \"key\": \"" + key.ToString("N") + "\" }");         
    
                foreach (var sendTo in to.Split(' ', ',', ';'))
                {
                    email.To.Add(sendTo);
                }
    
                if (cc != null)
                {
                    foreach (var sendCC in cc.Split(' ', ',', ';'))
                    {
                        email.CC.Add(sendCC);
                    }
                }
    
                var smtp = new MailClient().SmtpClient;
                smtp.EnableSsl = true;
                smtp.Send(email);
                return email;
            }
        }
    
        public class Mail<TModel> : Mail where TModel : class
        {
            public Mail(string templateName, TModel mailModel) : base(templateName)
            {
                Model = mailModel;
            }
        }
	
