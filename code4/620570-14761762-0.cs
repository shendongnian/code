        public class MyViewModel
        {
            [Compare("NewPassword", 
                     ErrorMessageResourceName = "RegisterModel_ConfirmPasswordError",
                     ErrorMessageResourceType = typeof(MvcApplication1.Messages))]
            public string Password { get; set; }
            public string NewPassword { get; set; }
        }
