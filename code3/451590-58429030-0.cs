<!-- language: c# -->
   public class Request
    {
        public IEnumerable<string> UserIds { get; set; }      
        public string  Body { get; set; }        
    }
I created the next validator
<!-- language: c# -->
public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {        
            RuleForEach(x => x.UserIds).NotNull().NotEmpty();            
            RuleFor(x => x.Body).NotNull().NotEmpty();      
        }
    }
