        public class BaseValidator<T> where T: BaseEntity
        {
            public virtual ValidationResult Validate(T entity)
            {
                 ... validate data annotations here ...
            }
        }
   
