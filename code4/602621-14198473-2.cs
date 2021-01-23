        [TestFixture]
        public class JSONTester
        {
            [Test]
            public void Json_deserialize()
            {
                var json = @"{
        ""?xml"": {
            ""@version"": ""1.0"",
            ""@encoding"": ""utf-8""
        },
        ""Persons"": {
            ""Person"": [{
                ""@Id"": ""1"",
                ""@Name"": ""John"",
                ""@Surname"": ""Smith""         
            },
            {
                ""@Id"": ""2"",
                ""@Name"": ""John"",
                ""@Surname"": ""Smith"",
                ""Skills"": {
                    ""Skill"": [{
                        ""@Id"": ""1"",
                        ""@Name"": ""Developer""                    
                    },
                    {
                        ""@Id"": ""2"",
                        ""@Name"": ""Tester""
                    }]
                }
            }]
        }
    }";
    
                var persons = JsonConvert.DeserializeObject<RootObject>(json);
    
                Assert.AreEqual(persons.Persons.Person[1].Skills.Skill.Count, 2);
    
            }
    
            public class RootObject
            {
                public Xml xml { get; set; }
                public Persons Persons { get; set; }
            }
    
            public class Xml
            {
                public string version { get; set; }
                public string encoding { get; set; }
            }
    
            public class Persons
            {
                public List<Person> Person { get; set; }
            }
            public class Skill
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
    
            public class Skills
            {
                public List<Skill> Skill { get; set; }
            }
    
            public class Person
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Surname { get; set; }
                public Skills Skills { get; set; }
            }
        }
