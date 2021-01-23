    [Serializable]
    [AttributeUsage(AttributeTargets.Assembly)]
    [MulticastAttributeUsage(MulticastTargets.Class | MulticastTargets.Struct)]
    [ProvideAspectRole(StandardRoles.PerformanceInstrumentation)]
    public sealed class DisableCoverageAttribute : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            Type disabledType = (Type)targetElement;
     
            var introducedExclusion = new CustomAttributeIntroductionAspect(
                  new ObjectConstruction(typeof (ExcludeFromCodeCoverageAttribute)));
     
            return new[] {new AspectInstance(disabledType, introducedExclusion)};
        }
    }
