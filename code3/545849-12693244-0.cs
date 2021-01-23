     public class IocValidator : DataAnnotationsModelValidator<ValidationAttribute>
    {
        public IocValidator(ModelMetadata metadata, ControllerContext context,
            ValidationAttribute attribute)
            : base(metadata, context, attribute) { }
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            IList<PropertyInfo> props = (from p in Attribute.GetType().GetProperties()
                                         where p.CanRead && p.CanWrite
                                             && (p.PropertyType.IsInterface || p.PropertyType.IsAbstract)
                                         select p).ToList();
            foreach (PropertyInfo prop in props)
            {
                var instance = IocHelper.Resolver.GetService(prop.PropertyType);
                if (instance != null)
                {
                    prop.SetValue(Attribute, instance, null);
                }
            }
            return base.Validate(container);
        }
    }
