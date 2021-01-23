        [HttpGet]
        public async Task<ActionResult> EditPartData(Guid? id)
        {
            // Find the data row and return the edit form
            Model input = await db.Models.FindAsync(id);
            return PartialView("EditModel", input);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> MyEditAction([Bind(Include =
           "Id,Fields,...")] ModelView input)
        {
            if (TryValidateModel(input))
            {  
                // save changes, return new data row  
                // status code is something in 200-range
                db.Entry(input).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return PartialView("dataRowView", (ModelView)input);
            }
            
            // set the "error status code" that will redisplay the modal
            Response.StatusCode = 400;
            // and return the edit form, that will be displayed as a 
            // modal again - including the modelstate errors!
            return PartialView("EditModel", (Model)input);
        }
