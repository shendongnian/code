        [HttpGet]
        public string GetDependents()
        {
            var dependents = _db.Dependents;
            return new JavaScriptSerializer().Serialize(dependents);
        }
