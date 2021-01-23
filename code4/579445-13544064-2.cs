        public class EmployeeValidator: BaseValidator<EmployeeEntity>
        {
            public override ValidationResult Validate(EmployeeEntity entity)
            {
                 base.Validate(entity);
                 
                 ... perform complex BLL calculations ...
            }
        }
