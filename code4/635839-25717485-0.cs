    public class RequestValidator : AbstractValidator<RequestViewModel>{
    	public readonly IDbContext context;
    
    	public RequestValidator(IKernel kernel) {
    		this.context = kernel.Get<IDbContext>();
    
    		RuleFor(r => r.Data).SetValidator(new DataMustHaveValidPartner(kernel)).When(r => r.RequestableKey == "join");
    	}
    }
