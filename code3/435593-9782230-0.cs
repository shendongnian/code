    <object id="MySessionFactory" type="Spring.Data.NHibernate.LocalSessionFactoryObject, Spring.Data.NHibernate">
      <property name="DbProvider" ref="DbProvider"/>
      <property name="MappingAssemblies">
        <list>
          <value>Your.AssemblyName</value>
        </list>
      </property>
      <property name="HibernateProperties">
      <!-- snip -->
    </object>
