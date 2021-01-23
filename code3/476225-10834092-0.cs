    public sealed EFNLSealedRepository : EFNLBaseRepository {
        public DoSomething() {
            // Access to dbContext should be allowed, because it is protected;
            // However, NLSubscriberDBContext should not be accessible.
            // This is an inconsistency flagged by the C# compiler.
            NLSubscriberDBContext context = dbContext;
        }
    }
