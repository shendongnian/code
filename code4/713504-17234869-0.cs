    public static class ServiceFacade
    {
        public static void ServiceOperation()
        {
            using (var service = new MyService())
            {
                service.Operation();
            }
        }
    }
