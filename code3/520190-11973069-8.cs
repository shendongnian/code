    using System;
    using System.Reflection.Emit;
    using System.Security;
    
    /*We need to either have User allow partially-trusted
     callers, or we need to have Program be fully-trusted.
     The former is the quicker to do, though the latter is
     more likely to be what one would want for real*/ 
    [assembly:AllowPartiallyTrustedCallers]
    
    namespace AllowCallsOnNull
    {
      public class User
      {
        public bool IsAuthorized
        {
          get
          {
            //Perverse because someone writing in C# should be expected to be friendly to
            //C#! This though doesn't apply to someone writing in another language who may
            //not know C# has difficulties calling this.
            //Still, don't do this:
            if(this == null)
            {
              Console.Error.WriteLine("I don't exist!");
              return false;
            }
            /*Real code to work out if the user is authorised
          	would go here. We're just going to return true
          	to demonstrate the point*/
          	Console.Error.WriteLine("I'm a real boy! I mean, user!");
          	return true;
          }
        }
      }
      class Program
      {
        public static void Main(string[] args)
        {
          //Set-up the helper that calls IsAuthorized on a
          //User, that may be null.
          DynamicMethod dynM = new DynamicMethod(string.Empty, typeof(bool), new Type[]{typeof(User)}, typeof(object));
          ILGenerator ilGen = dynM.GetILGenerator(7);
          ilGen.Emit(OpCodes.Ldarg_0);
          ilGen.Emit(OpCodes.Call, typeof(User).GetProperty("IsAuthorized").GetGetMethod());
          ilGen.Emit(OpCodes.Ret);
          Func<User, bool> CheckAuthorized = (Func<User, bool>)dynM.CreateDelegate(typeof(Func<User, bool>));
        
          //Now call it, first on null, then on an object
          Console.WriteLine(CheckAuthorized(null));    //false
          Console.WriteLine(CheckAuthorized(new User()));//true
          //Wait for input so the user will actually see this.
          Console.ReadKey(true);
        }
      }
    }
