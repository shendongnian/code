        public HttpResponseMessage InsertTempFile()
        {
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[0];
            //........
            // Code that adds my file to the database
            // and generates a new primary key for my file
            //.........
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(myNewId.ToString());
        
            return response;
        }
