            return new string[] { "value1", "value2" };
        }
        // GET /api/values/5
        public string Get(int id)
        {
            return "value";
        }
        // GET /api/values/5
        [HttpGet]
        public string GetByFamily()
        {
            return "Family value";
        }
