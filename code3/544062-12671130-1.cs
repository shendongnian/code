    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Web.Http;
    namespace CutomXmlFormater.Controllers
    {
    //[DataContract(Namespace = "")]
    public class Foo
    {
        //[DataMember]
        public string Bar { get; set; }
    }
    public class FoosController : ApiController
    {
        // GET api/foos/5
        public Foo Get(int id)
        {
            return new Foo() { Bar = "Test" };
        }
    }
