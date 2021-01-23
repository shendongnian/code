        public class EmployeeModel
        {
            [Required]
            public string Name {get; set;}
            ...
        }
        public class EmployeeEntity: BaseEntity
        {
            [Required]
            public string Name {get; set;}
            ...
        }
