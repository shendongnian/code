    public class EmployeeMap : ClassMapping<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.ID, map => { map.Generator(Generators.Identity); map.UnsavedValue(0); });
        }
    }
