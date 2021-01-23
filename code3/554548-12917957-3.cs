    public class GetEmployeeOfTheMonthQuery : IQuery<Employee>
    {
        [Range(1, 12)]
        public int Month { get; set; }
    }
    public class GetEmployeeOfTheMonthQueryHandler
        : IQueryHandler<GetEmployeeOfTheMonthQuery, Employee>
    {
        public Employee Handle(GetEmployeeOfTheMonthQuery query)
        {
            // todo: query the database, web service, disk, what ever.
        }
    }
