    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerCall,
    	ConcurrencyMode = ConcurrencyMode.Multiple
    )]
    public class MyService : IMyService
    {
}
