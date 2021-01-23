            public class Company
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string City { get; set; }
            }
    
            //[HttpGet]
            public JsonResult get_details(int id)
            {
                // Do all sql work including setting up connection, command, ect.
    
    
                Company entity = new Company();
    
                if (reader.read())
                {
                    entity.Id = int.Parse(reader["Id"].ToString());
                    entity.Name = reader["name"].ToString();
                    entity.City = reader["City"].ToString();
                }
                    
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
