    public static class DispatchStrategyfactory
    {
        public static void Dispatch<T>(T instance) where T : IRequest 
        {
            instance.Dispatch();
        } 
    }
