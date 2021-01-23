    using Routing.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    namespace Routing.Controllers
    {
        public class StudentsController : ApiController
        {
            static List<Students> Lststudents =
                  new List<Students>() { new Students { id=1, name="kim" },
               new Students { id=2, name="aman" },
                new Students { id=3, name="shikha" },
                new Students { id=4, name="ria" } };
            
            [HttpGet]
            public IEnumerable<Students> getlist()
            {
                return Lststudents;
            }
    
            [HttpGet]
            public Students getcurrentstudent(int id)
            {
                return Lststudents.FirstOrDefault(e => e.id == id);
            }
            [HttpGet]
            [Route("api/Students/{id}/course")]
            public IEnumerable<string> getcurrentCourse(int id)
            {
                if (id == 1)
                    return new List<string>() { "emgili", "hindi", "pun" };
                if (id == 2)
                    return new List<string>() { "math" };
                if (id == 3)
                    return new List<string>() { "c#", "webapi" };
                else return new List<string>() { };
            }
    
            [HttpGet]
            [Route("api/students/{id}/{name}")]
            public IEnumerable<Students> getlist(int id, string name)
            { return Lststudents.Where(e => e.id == id && e.name == name).ToList(); }
    
            [HttpGet]
            public IEnumerable<string> getlistcourse(int id, string name)
            {
                if (id == 1 && name == "kim")
                    return new List<string>() { "emgili", "hindi", "pun" };
                if (id == 2 && name == "aman")
                    return new List<string>() { "math" };
                else return new List<string>() { "no data" };
            }
        }
    }
