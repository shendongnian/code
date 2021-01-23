    using (SqlConnection cn = new SqlConnection(_connectionString))
    {
        cn.Open();
        var predicate = Predicates.Field<Foo>(f => f.foo_id, Operator.Eq, 1);
        IEnumerable<Foo> list = cn.GetList<Foo>(predicate);
        cn.Close();
    }
