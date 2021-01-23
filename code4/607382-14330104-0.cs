    [IntroduceInterface(typeof(IMyInterface)]
    public class CustomAspect : InstanceLevelAspect
    {
        [OnLocationSetValueAdvice]
        [MulticastPointcut(Targets = MulticastTargets.Field, Attributes = MulticastAttributes.Instance)]
        public void OnSetValue(LocationInterceptionArgs args)
        {
           ...
        }
    }
