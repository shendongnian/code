    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Resources;
    using System.Globalization;
    
    namespace QMVC.ViewModel.Home
    {
      public class TResViewModel
      {  
        [Required(ErrorMessageResourceType = typeof(QMVC.Properties.Resources), ErrorMessageResourceName = "Test")]
        public string Test2 { get; set; }
    
          }
        }
