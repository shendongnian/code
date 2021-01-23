    namespace NHibernateTutorialPart1
    {
        public partial class Form1 : Form
        {
    
            private Configuration myConfiguration;
            private ISessionFactory mySessionFactory;
            private ISession mySession;
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                myConfiguration = new Configuration();
                myConfiguration.Configure("hibernate_mysql.cfg.xml");
                mySessionFactory = myConfiguration.BuildSessionFactory();
                mySession = mySessionFactory.OpenSession();
    
                using (mySession.BeginTransaction())
                {
                    Contact lbContact=new Contact{FirstName="Nisha", LastName="Shrestha",ID=0};
                    mySession.Save(lbContact);
                    mySession.Transaction.Commit();
                }
            }
        }
    }
    
    **hibernate_mysql.cfg.xml**
    
    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
      <session-factory>
        <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
        <property name="dialect">NHibernate.Dialect.MySQLDialect</property>
        <property name="connection.driver_class">NHibernate.Driver.MySqlDataDriver</property>
        <property name="connection.connection_string">
          User Id=root;
          Server=localhost;
          Password=Password1;
          Database=nhibernatecontacts;
        </property>
    
        <!--This is good for Debugging but not otherwise-->
        <property name="show_sql">true</property>
    
        <!--<property name="proxyfactory.factory_class">NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu</property>-->
        <mapping assembly="NHibernateTutorialPart1"/>
      </session-factory>
    </hibernate-configuration>
    
    
    **contact.hbm.xml**
    
    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2"
                       assembly="NHibernateTutorialPart1"
                       namespace="NHibernateTutorialPart1">
      <class name="Contact" table="contact">
        <id name="ID" column="ID">
          <generator class="identity" />
        </id>
        <property name="FirstName" />
        <property name="LastName" />
      </class>
    </hibernate-mapping>
    
    **Contact class**
    
    
    namespace NHibernateTutorialPart1
    {
        public class Contact
        {
    
            public virtual int ID { get; set; }
            public virtual string FirstName { get; set; }
            public virtual string LastName { get; set; }
    
        }
    }
    
    
    **App.config**
    
    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="hibernate-configuration" type="NHibernate.Cfg.ConfigurationSectionHandler,NHibernate"/>
      </configSections>
    </configuration>
    
    You need to add reference for lesi.collection and NHibernate
    You need to do embeded resource for contact.hbm.xml and hibernate_mysql.cfg.xml
