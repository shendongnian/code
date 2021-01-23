    var s = DynamicSelectGenerator<SalesTeam, SalesTeamSelect>(
                "Name:SalesTeamName",
                "Employee.FullName:SalesTeamExpert"
                );
    var res = _context.SalesTeam.Select(s);
    public class SalesTeam
    {
        public string Name {get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
    public class SalesTeamSelect
    {
        public string SalesTeamName {get; set; }
        public string SalesTeamExpert {get; set; }
    }
