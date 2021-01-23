        /* Begin Model logic */
        public class LoginRegisterModel
        {
            public LoginModel LoginModel { get; set; }
            public RegisterModel RegisterModel { get; set; }
            public string sReturnURL { get; set; }
            public bool bIsActionLogin { get; set; }
            public bool bIsActionRegister { get; set; }
            public void IsActionLogin()
            {
                bIsActionLogin = true;
                bIsActionRegister = false;
            }
            public void IsActionRegister()
            {
                bIsActionLogin = false;
                bIsActionRegister = true;
            }
        }
        public class LoginRegisterModel
        {
            public LoginModel LoginModel { get; set; }
            public RegisterModel RegisterModel { get; set; }
            public string sReturnURL { get; set; }
            public bool bIsActionLogin { get; set; }
            public bool bIsActionRegister { get; set; }
            public void IsActionLogin()
            {
                bIsActionLogin = true;
                bIsActionRegister = false;
            }
            public void IsActionRegister()
            {
                bIsActionLogin = false;
                bIsActionRegister = true;
            }
        }
        public class RegisterModel
        {
            [Required]
            [Display(Name = "Email")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid.")]
            public string UserName { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
            /*End Model logic*/
            /*Begin Controller Logic*/
            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public ActionResult Login(LoginRegisterModel model, string sReturnURL)
            {
                model.IsActionLogin(); //flags that you are using Login Action
                //process your login logic here
            }
            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public ActionResult Register(LoginRegisterModel model, string sReturnURL)
            {
                model.IsActionRegister(); //flag Action Register action
                //process your register logic here
            }
            /*End Controller Logic*/
        /*Begin View Logic*/
        @model eCommerce.Models.LoginRegisterModel
        @{  
            /*Place this view logic in both the Login.cshtml and Register.cshtml. Now use the last Action called as a Boolean check against your validation messages, so unnecessary validation messages don't show up.*/
            bool bLoginCallBack = Model.bIsActionLogin; 
            bool bRegisterCallBack = Model.bIsActionRegister;
            MvcHtmlString htmlIcoWarn = new MvcHtmlString(" font awesome icon here ");
            MvcHtmlString htmlIcoHand = new MvcHtmlString(" font awesome icon here ");
        }
            @using (Html.BeginForm("Login", "Account", new { sReturnURL = Model.sReturnURL }))
            {
                @Html.AntiForgeryToken()
                if (bLoginCallBack)
                {
                    MvcHtmlString htmlLoginSummary = Html.ValidationSummary(true);
                    if (!htmlLoginSummary.ToHtmlString().Contains("display:none"))
                    {
                    @:@(htmlIcoWarn)@(htmlLoginSummary)
                    }
                }
                @Html.LabelFor(m => m.LoginModel.UserName)
                @Html.TextBoxFor(m => m.LoginModel.UserName, new { @placeholder = "Email" })
            @if (bLoginCallBack)
            {
                MvcHtmlString htmlLoginUsername = Html.ValidationMessageFor(m => m.LoginModel.UserName);
                if (!htmlLoginUsername.ToHtmlString().Contains("field-validation-valid"))
                {
                @:@(htmlIcoHand) @(htmlLoginUsername)
                }
            }
                @Html.LabelFor(m => m.LoginModel.Password)
                @Html.PasswordFor(m => m.LoginModel.Password, new { @placeholder = "Password" })
            @if (bLoginCallBack)
            {
                MvcHtmlString htmlLoginPassword = Html.ValidationMessageFor(m => m.LoginModel.Password);
                if (!htmlLoginPassword.ToHtmlString().Contains("field-validation-valid"))
                {
                @:@(htmlIcoHand) @(htmlLoginPassword)
                }
            }
                    @Html.CheckBoxFor(m => m.LoginModel.RememberMe)
                    @Html.LabelFor(m => m.LoginModel.RememberMe)
	            <button type="submit" class="btn btn-default">Login</button>
            }
        @using (Html.BeginForm("Register", "Account", new { sReturnURL = Model.sReturnURL }))
        {
            @Html.AntiForgeryToken()
            if (bRegisterCallBack)
            {
                MvcHtmlString htmlRegisterSummary = Html.ValidationSummary(true);
                if (!htmlRegisterSummary.ToHtmlString().Contains("display:none"))
                {
                    @:@(htmlIcoWarn)@(htmlRegisterSummary)
                }
            }
                @Html.LabelFor(m => m.RegisterModel.UserName)
                @Html.TextBoxFor(m => m.RegisterModel.UserName, new { @placeholder = "Email" })
            @if (bRegisterCallBack)
            {
                MvcHtmlString htmlRegisterUsername = Html.ValidationMessageFor(m => m.RegisterModel.UserName);
                if (!htmlRegisterUsername.ToHtmlString().Contains("field-validation-valid"))
                {
                @:@(htmlIcoHand) @(htmlRegisterUsername)
                }
            }
                @Html.LabelFor(m => m.RegisterModel.Password)
                @Html.PasswordFor(m => m.RegisterModel.Password, new { @placeholder = "Password" })
            @if (bRegisterCallBack)
            {
                MvcHtmlString htmlRegisterPassword = Html.ValidationMessageFor(m => m.RegisterModel.Password);
                if (!htmlRegisterPassword.ToHtmlString().Contains("field-validation-valid"))
                {
                @:@(htmlIcoHand) @(htmlRegisterPassword)
                }
            }
                @Html.LabelFor(m => m.RegisterModel.ConfirmPassword)        @Html.PasswordFor(m => m.RegisterModel.ConfirmPassword, new { @placeholder = "Confirm Password" })                
            @if (bRegisterCallBack)
            {
                MvcHtmlString htmlRegisterConfirmPassword = Html.ValidationMessageFor(m => m.RegisterModel.ConfirmPassword);
                if (!htmlRegisterConfirmPassword.ToHtmlString().Contains("field-validation-valid"))
                {
                @:@(htmlIcoHand) @(htmlRegisterConfirmPassword)
                }
                <button type="submit" class="btn btn-default">Signup</button>
            }
        }
        /*End View Logic*/
