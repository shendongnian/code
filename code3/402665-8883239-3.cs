    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using ProjectsMVC.Helpers;
    
    namespace ProjectsMVC.Models
    {
        [MetadataType(typeof(User_Validation))]
        public partial class User
        {
            public string ProperName
            {
                get
                {
                    return string.Format("{0} {1}", this.FirstName, this.LastName);
                }
            }
    
            public string DirectoryName
            {
                get
                {
                    return string.Format("{0}, {1}", this.LastName, this.FirstName);
                }
            }
    
            public string IsUserActive
            {
                get
                {
                    return Dictionaries.TrueOrFalse.First(t => t.Key == this.IsActive).Value.ToString();
                }
            }
        }
    
        public class User_Validation
        {
            [Display(Name = "eName")]
            [Required(ErrorMessage = "required")]
            [ValidateEname(ErrorMessage = "invalid")]
            public string UserName { get; set; }
    
            [Display(Name = "First DirectoryName")]
            [Required(ErrorMessage = "required")]
            public string FirstName { get; set; }
    
            [Display(Name = "Last DirectoryName")]
            [Required(ErrorMessage = "required")]
            public string LastName { get; set; }
    
            [Display(Name = "Email Address")]
            [Required(ErrorMessage = "required")]
            [ValidateEmail(ErrorMessage = "invalid")]
            public string EmailAddress { get; set; }
    
            [Display(Name = "Active User")]
            [Required(ErrorMessage = "required")]
            public bool IsActive { get; set; }
        }
    }
