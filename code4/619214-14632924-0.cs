        public ActionResult SubmitFormWithFormCollection(FormCollection parameters)
        {
            foreach (string param in parameters)
            {
                ViewData[param] = parameters[param];
            }
        
            return View();
        }
