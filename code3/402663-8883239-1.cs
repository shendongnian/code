    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    
    namespace ProjectsMVC.Helpers
    {
        #region RegularExpressionAttributes
        /// <summary>
        /// Email validation regular expression attribute
        /// </summary>
        /// <remarks>Validates person@someplace.com, some.person@someplace.com, some_person@some+place.com and combinations thereof.</remarks>
        public class ValidateEmailAttribute : RegularExpressionAttribute
        {
            // public ValidateEmailAttribute()
            //     : base(@"^\S?([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") { }
    
    		public ValidateEmailAttribute()
    			: base(@)@"^\S?([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@someplace.com$") {}
        }	
    
        #region DataAnnotationsModelValidator
        public class EmailValidator : DataAnnotationsModelValidator<ValidateEmailAttribute>
        {
            #region Properties
            /// <summary>
            /// Error message
            /// </summary>
            private readonly string _errorMessage;
    
            /// <summary>
            /// Regular expression pattern
            /// </summary>
            private readonly string _pattern;
            #endregion
    
            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="EmailValidator"/> class.
            /// </summary>
            /// <param name="metaData">The meta data.</param>
            /// <param name="context">The context.</param>
            /// <param name="attribute">The attribute.</param>
            public EmailValidator(ModelMetadata metaData, ControllerContext context, ValidateEmailAttribute attribute)
                : base(metaData, context, attribute)
            {
                this._errorMessage = attribute.ErrorMessage;
                this._pattern = attribute.Pattern;
            }
    
            #endregion
    
            #region Methods
            /// <summary>
            /// Retrieves a collection of client validation rules.
            /// </summary>
            /// <returns>A collection of client validation rules.</returns>
            public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
            {
                var rule = new ModelClientValidationRegexRule(this._errorMessage, this._pattern);
                return new[] { rule };
            }
    
            #endregion
        }
    }
