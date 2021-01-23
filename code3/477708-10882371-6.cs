    public class Is_dateX_valid : ISpecification<MyAggregate>
        {
            private readonly DateTime _dateX;
    
            public Is_data_consuntivazione_valid(DateTime dateX)
            {
                Contract.Requires<ArgumentNullException>(dateX== DateTime.MinValue);
    
                _dateX= dateX;
            }
    
            public bool IsSatisfiedBy(MyAggregate i)
            {
                if (_dateX> DateTime.Now)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("datex greater than now"));
                    return false;
                }
    
                return true;
            }
        }
    
        public class Has_start_date_greater_than_end_date : ISpecification<MyAggregate>
        {
            private readonly DateTime _start;
            private readonly DateTime _end;
    
            public Has_start_date_greater_than_end_date(DateTime start, DateTime end)
            {
                Contract.Requires<ArgumentNullException>(start == DateTime.MinValue);
                Contract.Requires<ArgumentNullException>(start == DateTime.MinValue);
    
                _start = start;
                _end = end;
            }
    
            public bool IsSatisfiedBy(MyAggregate i)
            {
                if (_start > _end)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage(start date greater then end date"));
                    return false;
                }
    
                return true;
            }
        }
