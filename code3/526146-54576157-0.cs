c#
        public Action<dynamic> GetDynamicAction(/* some params */)
        {
            return oDyn =>
            {
                //here is the action code with the use of /* some params */
            };
        }
Example with a basic action handler :
c#
public class ActionHandler
{
     public ReturnType DoAction<T>(Action<T> t)
     {
         //whatever needed
     }
}
Use case :
c#
/* some params */ = Any runtime type specific data (in my case I had a Type and a MethodInfo passed as parameters and that were called in the action)
var genericMethod = actionHandler.GetType().GetMethod(nameof(ActionHandler.DoAction));
var method = genericMethod.MakeGenericMethod(runtimeGenericType);
var actionResult = (ReturnType) method.Invoke(actionHandler, new object[]
                    {
                        GetDynamicAction(/*some params*/)
                    }
                );
