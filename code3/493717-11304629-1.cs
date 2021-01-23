    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;
    
    namespace WebService4ExtJS
    {
        /// <summary>
        /// Summary description for Service1
        /// </summary>
        [ScriptService]
        public class Service : System.Web.Services.WebService
        {
            [WebMethod(EnableSession = true)]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true, XmlSerializeString = false)]
            public List<Student> GetStudentList()
            {
                List<Student> obList = new List<Student>();
                obList.Add(new Student(1, "John", "Doe"));
                obList.Add(new Student(2, "Michael", "Crowd"));
                obList.Add(new Student(3, "Gunnar", "Rasmundsson"));
                obList.Add(new Student(4, "Alicia", "Mankind"));
                return obList;
            }
        }
    
        public class Student
        {
            private int _stid;
            private string _stname;
            private string _stservice;
    
            public Student() { }
            public Student(int stid, string stname, string stservice)
            {
                this.StId = stid;
                this.StName = stname;
                this.StService = stservice;
            }
    
            public int StId
            {
                get { return this._stid; }
                set { this._stid = value; }
            }
            public string StName
            {
                get { return this._stname; }
                set { this._stname = value; }
            }
            public string StService { get { return this._stservice; } set { this._stservice = value; } }
        }
    }
