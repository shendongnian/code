    <object id="MySessionFactory" type="Spring.Data.NHibernate.LocalSessionFactoryObject, Spring.Data.NHibernate21">
      <property name="DbProvider" ref="DbProvider"/>
      <property name="MappingResources">
        <list>
          <value>assembly://SofPOC.Net4.NH2.Spring13/SofPOC.Questions.SerializeSession.Entities/MasterEtt.hbm.xml</value>
          <value>assembly://SofPOC.Net4.NH2.Spring13/SofPOC.Questions.SerializeSession.Entities/DetailEtt.hbm.xml</value>
        </list>
      </property>
      <property name="HibernateProperties">
        <dictionary>
          <!--<entry key="connection.provider" value="AcessaDados.NHibernate.Connection.SiefDriverConnectionProvider, AcessaDados"/>-->
          <entry key="dialect" value="NHibernate.Dialect.SQLiteDialect"/>
          <entry key="connection.driver_class" value="NHibernate.Driver.SQLite20Driver"/>
          <entry key="current_session_context_class" value="Spring.Data.NHibernate.SpringSessionContext, Spring.Data.NHibernate21"/>
    
          <entry key="hbm2ddl.keywords" value="none"/>
          <entry key="query.startup_check" value="false"/>
          <entry key="show_sql" value="true"/>
          <entry key="format_sql" value="true"/>
          <entry key="use_outer_join" value="true"/>
          <entry key="bytecode.provider" value="SofPOC.Questions.SerializeSession.Spring.Data.NHibernate.Bytecode.BytecodeProviderSrlzSupport, SofPOC.Net4.NH2.Spring13"/>
          <entry key="proxyfactory.factory_class" value="SofPOC.Questions.SerializeSession.Spring.Data.NHibernate.Bytecode.ProxyFactoryFactorySrlzSupport, SofPOC.Net4.NH2.Spring13"/>
        </dictionary>
      </property>
    </object>
