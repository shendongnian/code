    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.ComponentModel;
    
    /// <summary>
    /// Formatting the mytable -table fields.
    /// </summary>
    
    [MetadataType(typeof(mytableMetadata))]
    public partial class mytable
    {
    
    }
    public class mytableMetadata
    {
        [DisplayFormat(HtmlEncode = false)]
        [UIHint("CKEditor")]
        public object myfield { get; set; }
    }
