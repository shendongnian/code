        using System.ServiceModel;
        using System.IdentityModel.Selectors;
        namespace MyService
        {
            public class CustomUserNameValidator : UserNamePasswordValidator
            {
                public override void Validate(string userName, string password)
                {
                    if (!(userName == "testMan" && password == "pass"))
                        throw new FaultException("Incorrect login or password");
                  
                    // save your Usermame and Password for future usage.
                 }
            }
        }
