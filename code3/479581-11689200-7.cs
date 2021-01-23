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
        [DisplayFormat(HtmlEncode = false)]  // The field is displayed as HTML, when not edited. 
        [UIHint("CKEditor")]                 // The field is edited with CKEditor. 
        public object myfield { get; set; }
    }
