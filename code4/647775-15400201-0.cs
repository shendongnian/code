    class AbcWebWorkContext : IWebWorkContext
    {
        private WebWorkerContext _inner = new WebWorkerContext();
        public Customer CurrentCustomer { ... }
    }
