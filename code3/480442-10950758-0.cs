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
        private static ResourceManager r = QMVC.Properties.Resources.ResourceManager;
    
        [Required(ErrorMessage = r.GetString("Test", CultureInfo.CurrentUICulture))]
        public string Test { get; set; }
      }
    }
