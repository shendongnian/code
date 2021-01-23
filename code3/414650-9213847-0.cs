    <?xml version="1.0" encoding="utf-8"?>
        <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
          <reflection-optimizer use="false" />
          <session-factory name="BpSpedizioni.MsSql">
            <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
            <property name="connection.driver_class">NHibernate.Driver.SqlClientDriver</property>
            <property name="dialect">NHibernate.Dialect.MsSql2008Dialect</property>
            <!-- <property name="connection.connection_string">Data Source=(local); Initial Catalog=NHibernate; Trusted_Connection=true;</property> -->
            <property name="current_session_context_class">web</property>
            <property name="adonet.batch_size">100</property>
            <property name="command_timeout">120</property>
            <property name="max_fetch_depth">3</property>
            <property name='prepare_sql'>true</property>
            <property name="query.substitutions">true 1, false 0, yes 'Y', no 'N'</property>
            <property name='proxyfactory.factory_class'>NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle</property>
            <mapping assembly="BpSpedizioni.Services"/>
          </session-factory>
    </hibernate-configuration>
