        [HttpPost]
        public ActionResult LoadJson(FormCollection collection)
        {
            dynamic values = JsonValue.Parse(collection["values"]);       
            for(int i = 0; i < values.Count; i++)
            {
                var _output = string.Format("My name is {0} and I'm {1} of age", values[i].Name, values[i].Age);
                Console.WriteLine(_output);
            }
            return RedirectToAction("Index");
        }
        
