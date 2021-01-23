     namespace ETL_Framework_UI
    {
    [MetadataType(typeof(DataObjectMD))]
    public partial class DATA_OBJECT:IValidatableObject
    {
      
        public class DataObjectMD
        {
            [Required(ErrorMessage="The object name is required")]
            [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
            public string OBJECT_NAME { get; set; }
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ETLDbDataContext db = new ETLDbDataContext();
            var field = new[] { "OBJECT_NAME" };
            var param = db.DATA_OBJECTs.SingleOrDefault(r => r.OBJECT_NAME == OBJECT_NAME && r.OBJECT_ID != OBJECT_ID);
            if (param != null)
            {
                yield return new ValidationResult("Object name is already in use. ", field);
    }
