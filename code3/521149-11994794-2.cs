    using System;
    
    namespace SnippetTool.Repositories
    {
        public class DefaultValidator
        {
           // whatever your "default" validation is, may just return true...
        }
        public abstract class ARepository<TProvider> : ARepository<TProvider, DefaultValidator>
            where TProvider : class
        {
            protected ARepository(TProvider provider) : base(provider, new DefaultValidator());
            {
            }
            // needs no new logic, just any specialized constructors...
        }
    
        public abstract class ARepository<TProvider, TValidator> 
             where TProvider : class 
             where TValidator : class
        {
            public TValidator Validator { get; set; }
    
            protected ARepository(TProvider provider, TValidator validator) 
            {
                Provider = provider;
                Validator = validator;
            }
            // all the logic goes here...
        }
    }
