         if(!ModelState.IsValid {
                    List<string> errorlist=new List<string>();
                    foreach (var value in ModelState.Values)
                    {
                        foreach(var error in value.Errors)
                        errorlist.Add( error.Exception.ToString());
                        //errorlist.Add(value.Errors);
                    }
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest,errorlist);
