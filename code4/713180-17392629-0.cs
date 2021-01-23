    public class BaseTypeBindingGenerator<InterfaceType> : IBindingGenerator
    {
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            if (type != null && !type.IsAbstract && type.IsClass && typeof(InterfaceType).IsAssignableFrom(type))
            {
                string.Format("Binds '{0}' to '{1}' as '{2}", type, type.Name, typeof(InterfaceType)).Dump();
            
                yield return bindingRoot.Bind(typeof(InterfaceType))
                                        .To(type)
                                        .Named(type.Name) as IBindingWhenInNamedWithOrOnSyntax<object>;
            }
        }
    }
