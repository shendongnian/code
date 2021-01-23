      public class Person
            {
                public Int32 Id { get; set; }
                public String Name { get; set; }
                public Document oDocument { get; set; }
            }
            public class Document
            {
                public String Type { get; set; }
                public String Code { get; set; }
            }
        
         List<Person> list = new List<Person>();
         dgvPersona.DataSource= list.Select(data => new { data.Name, data.oDocument.Code }).ToList();
