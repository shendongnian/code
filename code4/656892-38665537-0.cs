        public ActionResult Update(MyViewModel mVM)
        {
            if(mVM.Role == "Role" && mVM.Property == null)
            {
                ModelState.Remove("Property");
            }
            if (ModelState.IsValid)
            {
               // code...
            }
         }
