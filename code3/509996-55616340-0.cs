c#
public class ComponentSelector : DefaultTypedFactoryComponentSelector
{
    protected override Arguments GetArguments(MethodInfo method, object[] arguments)
    {
        if (arguments == null)
            return null;
        Arguments argumentMap = new Arguments();
        ParameterInfo[] parameters = method.GetParameters();
        List<Type> types = parameters.Select(p => p.ParameterType).ToList();
        List<Type> duplicateTypes = types.Where(t => types.Count(type => type == t) > 1).ToList();
        for (int i = 0; i < parameters.Length; i++)
        {
            if (duplicateTypes.Contains(parameters[i].ParameterType))
                argumentMap.Add(parameters[i].Name, arguments[i]);
            else
                argumentMap.Add(parameters[i].ParameterType, arguments[i]);
        }
        return argumentMap;
    }
}
As you can see in my implementation, you need to handle the case when your constructor has multiple parameters with the same type.  
In that case you have to resolve by parameter name because `Castle.Windsor` will use the first parameter of a type for every parameter that has the same type.
To use your own `ComponentSelector` you have to register it with your `IWindsorContainer` as well:
c#
container.Register(Component.For<ComponentSelector, ITypedFactoryComponentSelector>());
Finally you have to tell your factory to use your own `ComponentSelector` as its component selector:
c#
container.Register(Component.For<ITypedFactory2>().AsFactory(f => f.SelectedWith<ComponentSelector>()));
For more information check the [official documentation][1] on how to use custom component selectors.
  [1]: https://github.com/castleproject/Windsor/blob/master/docs/typed-factory-facility-interface-based.md#custom-itypedfactorycomponentselectors
