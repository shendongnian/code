    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    namespace TestPortal.Areas.JB.Models.Example
    {
        public class ExampleIndex
        {
            public ExampleIndex()
            {
                this.DropDownData = new List<SelectListItem>();
            }
            public List<SelectListItem> DropDownData
            {
                get;
                set;
            }
        }
    }
