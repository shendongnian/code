    [AttributeUsage(AttributeTargets.Method)]
    public class ExtensionAspectAttribute : MethodLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            var constructorInfo = typeof (System.Runtime.CompilerServices.ExtensionAttribute).GetConstructor(Type.EmptyTypes);
            var objectConstruction = new ObjectConstruction(constructorInfo);
            var aspectInstance = new CustomAttributeIntroductionAspect(objectConstruction);
            yield return new AspectInstance(targetElement, aspectInstance);
        }
    }
