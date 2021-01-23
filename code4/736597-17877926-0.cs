    <connectionStrings>
      <add name="MyConnString" connectionString="Server=(local);initial catalog=DemoDB;Integrated Security=SSPI" />
        </connectionStrings>
    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
    <session-factory>
      <property name="proxyfactory.factory_class">NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle</property>
      <property name="dialect">NHibernate.Dialect.MsSql2008Dialect, NHibernate</property>
      <property name="connection.connection_string_name">MyConnString</property>     
    </session-factory>
