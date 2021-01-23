    public class ValidatorFactory : IValidatorFactory 
    {
        private readonly IDependencyResolver _dependencyResolver;
        // taken from the attribute Validation factory
        public ValidatorFactory(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }
        /// <summary>
        /// Gets a validator for the appropriate type.
        /// 
        /// </summary>
        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)this.GetValidator(typeof(T));
        }
        /// <summary>
        /// Gets a validator for the appropriate type.
        /// 
        /// </summary>
        public virtual IValidator GetValidator(Type type)
        {
            if (type == (Type)null)
                return (IValidator)null;
            var validatorAttribute = (ValidatorAttribute)Attribute.GetCustomAttribute((MemberInfo)type, typeof(ValidatorAttribute));
            if (validatorAttribute == null || validatorAttribute.ValidatorType == (Type) null)
            {
                return (IValidator) null;
            }
            else
            {
                return _dependencyResolver.GetService(validatorAttribute.ValidatorType) as IValidator;
            }
        }
    }
 
