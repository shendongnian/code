    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    public class Foo
    {
        public int IDfoo{ get; set; }
        [DisplayFormat(DataFormatString = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.ToString())]
        public DateTime createDate { get; set; }
    }
    or without the using
    
    public class Foo
    {
        public int IDfoo{ get; set; }
        [DisplayFormat(DataFormatString = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.ToString())]
        public DateTime createDate { get; set; }
    }
