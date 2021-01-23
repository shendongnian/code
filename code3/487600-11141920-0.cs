    namespace System.ServiceModel.DomainServices.Server 
    {
    	// Just put this into your WPF app :)
    	[AttributeUsageAttribute(AttributeTargets.Property|AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    	public class IncludeAttribute : Attribute {}
    }
