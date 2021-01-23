    <?xml version="1.0" encoding="utf-8"?>
    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
      <session-factory>        
        <property name="proxyfactory.factory_class">NHibernate.ByteCode.Castle.ProxyFactoryFactory,NHibernate.ByteCode.Castle</property>
        <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>    
        <property name="connection.driver_class">NHibernate.Driver.SqlClientDriver</property>  
        <property name="connection.connection_string">Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\1\Desktop\Application+\Application\Application.mdf;Integrated Security=True;User Instance=True</property>    
        <property name="dialect">NHibernate.Dialect.MsSql2008Dialect</property> 
        <property name="show_sql">true</property>
      </session-factory>
    </hibernate-configuration>
