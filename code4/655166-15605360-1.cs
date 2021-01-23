    Property(x => x.SomeProperty,
             pm =>
             {
                 pm.Type(NHibernateUtil.AnsiString);
                 pm.Length(6);
                 pm.Column(cm => cm.SqlType("char(6)"));
             });
