       public class CustomInstanceProvider : StandardInstanceProvider {
          protected override ConstructorArgument[] GetConstructorArguments(MethodInfo methodInfo, object[] arguments) {
                         var parameters = methodInfo.GetParameters();
                var constructorArguments = new ConstructorArgument[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    constructorArguments[i] = new ConstructorArgument(parameters[i].Name, arguments[i], true);
                }
    
                return constructorArguments;
          }
       }
