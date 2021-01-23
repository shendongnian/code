    class ParameterModel: JobParameter
    {
        public JobParameter ToDomain()
        {
            var domainObject = JobParameter.Factory(Type);
            Mapper.Map(this, domainObject);
            return domainObject;
        }
        public bool Validate()
        {
            var dom = ToDomain();
            return TryValidate(dom);
        }
    }
