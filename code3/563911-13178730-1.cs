    public class Person : IDataErrorInfo // Represents person data.
    {
        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>
        /// <remarks>
        /// Empty string or null are not allowed.
        /// Allow minimum of 2 and up to 40 uppercase and lowercase.
        /// </remarks>
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,40}$")]        
        public string FirstName{ get; set;}
    
        /// <summary>
        /// Gets or sets the person's last name.
        /// </summary>
        /// <remarks>
        /// Empty string or null are not allowed.
        /// </remarks>
        [Required]
        public string LastName { get; set;}
    
        public int Age{ get; set;}
    
        public string Error // Part of the IDataErrorInfo Interface
        {
            get { throw new NotImplementedException(); }
        }
    
     string IDataErrorInfo.this[string propertyName] // Part of the IDataErrorInfo Interface
        {
            get { return OnValidate(propertyName); }
        }
    
        /// <summary>
        /// Validates current instance properties using Data Annotations.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Invalid property name", propertyName);
    
            string error = string.Empty;
            var value = this.GetType().GetProperty(propertyName).GetValue(this, null);
            var results = new List<ValidationResult>(1);
    
            var context = new ValidationContext(this, null, null) { MemberName = propertyName };
    
            var result = Validator.TryValidateProperty(value, context, results);
    
            if (!result)
            {
                var validationResult = results.First();
                error = validationResult.ErrorMessage;
            }
    
            return error;
        }
    }
