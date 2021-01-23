    public class EmployeeRepository : AbstractRepository<Employe>
        {
            protected sealed override string TableName
            {
                get
                {
                    return "dbo.Employees";
                }
            }
    
            protected sealed override Employe DataRowToModel(DataRow dr)
            {
                if (dr == null)
                {
                    return null;
                }
                return new Employe
                {
                    Id = dr.Field<int>("id"),
                    Name = dr.Field<string>("name"),
                    Surname = dr.Field<string>("surname"),
                    Age = dr.Field<int>("age")
    
                };
            }
    
    
            public override void Insert(Employe entity)
            {
                var query = $@"insert into {TableName} (name, surname, age)
                                values({entity.Name},{entity.Surname},{entity.Age})";
                DAL.Query(query);
            }
    
            public override bool Update(Employe entity)
            {
                throw new NotImplementedException();
            }
        }
