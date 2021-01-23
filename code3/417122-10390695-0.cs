    public class CustomValidation
    {
         public static ValidationResult ValidateUnique(object o, ValidationContext c)
         {
             #if SILVERLIGHT
                 //Do actual validation client-side:
                 MyObject mo = c.ObjectInstance as mo; //Object we are checking is type MyObject
                 MyDS ctx = new MyDS; //Domain Service
                 System.ServiceModel.DomainServices.Client.InvokeOperation<bool> 
                        isUnique = //some invoke operation in Domain Service;
			
                 isUnique .Completed += (s, e) =>
		         {
                     if (!isUnique .HasError && !isUnique.Value)
                     {
                          //return error;
                          mo.ValidationErrors.Add(error);
                     }
                 };
             #endif
             //Server-side always returns success:
             return ValidationResult.Success;
         }
    }
