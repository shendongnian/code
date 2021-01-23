    public class MyCustomValidationAttribute : ValidationAttribute
    {
 		protected override ValidationResult IsValid(object value, ValidationContext ctx)
 		{
            // get the property
			var prop = ctx.ObjectType.GetProperty(ctx.MemberName);
			
			// get the current value (assuming it's a string property)
			var oldVal = prop.GetValue(ctx.ObjectInstance) as string;
			
			// create a new value, perhaps by manipulating the current one
			var newVal = "???";
			
			// set the new value
			prop.SetValue(ctx.ObjectInstance, newVal);
			return base.IsValid(value, ctx);
		}
    }
