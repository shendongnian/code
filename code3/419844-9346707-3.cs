    public class AutoExceptMoqPropertiesCommand : AutoPropertiesCommand<object>
    {
        public AutoExceptMoqPropertiesCommand()
            : base(new NoInterceptorsSpecification())
        {
        }
        protected override Type GetSpecimenType(object specimen)
        {
            return specimen.GetType();
        }
        private class NoInterceptorsSpecification : IRequestSpecification
        {
            public bool IsSatisfiedBy(object request)
            {
                var fi = request as FieldInfo;
                if (fi != null)
                {
                    if (fi.Name == "__interceptors")
                        return false;
                }
                return true;
            }
        }
    }
