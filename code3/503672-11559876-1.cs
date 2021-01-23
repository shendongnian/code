      using System.ServiceModel;
      using System.IdentityModel.Selectors;
      namespace MyService
      {
           public class CustomUserNameValidator : UserNamePasswordValidator
           {
                public override void Validate(string userName, string password)
                {
                    if (!(userName == "testMan" && password == "pass"))
                    {
                        throw new FaultException("Incorrect login or password");
                    }
                    //save your user Name and pass 
                    //(in static properies of some class for example) for future usage.
 
                }
           }
      }
