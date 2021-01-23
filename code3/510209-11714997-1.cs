    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Web.Mvc;
    using JustAdminIt.Areas.JBI.Models;
    namespace JustAdminIt.Areas.JBI.ViewModels
    {
        public class ImageViewModel
        {
            public Image Image { get; set; }
            public Product Product { get; set; }
        }
    }
