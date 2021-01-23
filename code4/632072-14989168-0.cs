    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication3.Models
    {
        [Serializable]
        public class ObjectADAO
        {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
        }
        [Serializable]
        public class ObjectBDAO
        {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
        }
    }
    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2"
                       assembly="ConsoleApplication3"
                       namespace="ConsoleApplication3.Models">
      <class name="ObjectADAO">
        <id name="Id" type="Int32" generator="native"/>
        <property name="Name" />
      </class>
    </hibernate-mapping>
    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2"
                       assembly="ConsoleApplication3"
                       namespace="ConsoleApplication3.Models">
      <class name="ObjectBDAO">
        <id name="Id" type="Int32" generator="native"/>
        <property name="Name" />
      </class>
    </hibernate-mapping>
