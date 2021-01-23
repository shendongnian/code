    namespace EFPocos
    {
        /// <summary>
        ///  Your EF POCO
        /// </summary>
        public class Question
        {
            public virtual int Id { get; set; }
            public virtual string QuestionText { get; set; }
            public virtual int QuestionGroupId { get; set; }
        }
    }
    
    namespace UIViewModels
    {
        /// <summary>
        ///  Your ViewModel 'derivative', but sans Annotation decoration
        /// </summary>
        [MetadataType(typeof(QuestionUIMetaData))]
        public class QuestionViewModel : EFPocos.Question, IValidatableObject
        {
            public string SubmittedValue { get; set; }
    
            #region IValidatableObject Members
    
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (Id % 2 == 0)
                {
                    yield return new ValidationResult("Some rule has fired");
                }
            }
    
            #endregion
        }
    
        /// <summary>
        /// Annotations go here ... and we may as well just AutoMapped a simple ViewModel
        /// </summary>
        public class QuestionUIMetaData
        {
            [HiddenInput]
            public int Id { get; set; }
            [Required()]
            public string QuestionText { get; set; }
            [Required()]
            [DisplayName("Select Group ...")]
            public int QuestionGroupId { get; set; }
            [DisplayName("Question is Here")]
            [StringLength(50, ErrorMessage = "Too Long!!")]
            public string SubmittedValue { get; set; }
        }
    }
