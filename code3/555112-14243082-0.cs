foreach (ConnectionStringSettings location in ConfigurationManager.ConnectionStrings)
{
    ConnectionStringSettings localLocation = location;
    For&lt;INHibernateSessionFactory&gt;()
        .Add(x =&gt; new NHibernateSessionFactory(localLocation.Name, GetSessionFactory(localLocation.ConnectionString)));
}
