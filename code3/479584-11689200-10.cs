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
        // The CKEditor cannot check the length of myfield, and the 
        // DataAnnotations StringLengthAttribute doesn't work with CKEditor,
        // so you have to custom check. 
        // 
        // This works as expected only when NOT debugging. 
        // 
        // In debug mode the application will open a window saying 
        // "ValidationException was unhandled by user code",
        // but the message is shown as it is set below in the code. 
        // Hit F5 again, and application will continue OK.
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (this._myfield.Length > 1024)
            {
                throw new ValidationException(
                   "Length of myfield must be less than 1025 characters.");
            }    }
    
    public class mytableMetadata
    {
        [DisplayFormat(HtmlEncode = false)]  // The field is displayed as HTML, when not edited. 
        [UIHint("CKEditor")]                 // The field is edited with CKEditor. 
        public object myfield { get; set; }
    }
