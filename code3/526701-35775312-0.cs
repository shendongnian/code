        public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {    
        		public RequiredAttribute()
        		{
        		}
        
                protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                		{
                			string displayName = validationContext.DisplayName;
                			ValidationResult result = base.IsValid(value, validationContext);
                			if (result != null)
                				result.ErrorMessage = string.Format(GetTranslatation("RequiredField"), displayName);
                			return result;
                		}
                }
        }
