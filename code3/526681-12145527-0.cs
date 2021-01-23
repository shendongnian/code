    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            For<IUserInputEntity>().Use<UserInputEntity>();
        }
    }
