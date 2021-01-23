        [Route("Cars/deteals/{id:int}")]
        public ContentResult deteals(int id)
        {
            return Content("<b>Cars ID Is " + id + "</b>");
        }
        
        [Route("Cars/deteals/{name}")]
        public  ContentResult deteals(string name)
        {
            return Content("<b>Car name Is " + name + "</b>");
        }
