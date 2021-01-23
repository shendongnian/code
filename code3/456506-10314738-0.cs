     public static class SomeBusinessObjectFactory
     {
            public static SomeBusinessObject Create()
            {
                return new SomeBusinessObject(
                        new SomethingChangedNotificationService(new EmailErrorHandler()),
                        new EmailErrorHandler(),
                        new MyDao(new EmailErrorHandler()));
            }
     }
