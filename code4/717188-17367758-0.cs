    using TestApp.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    
    namespace TestApp.Models
    {
        public class LoginModel
        {
            public string Email { get; set; }
            [Required]
            [MinLength(5, ErrorMessageResourceName="Test", ErrorMessageResourceType=typeof(Resources))]
            public string Password { get; set; }
        }
    }
