        public string result
        {
            get
            {
                return db.Emp.SelectMany(c => db.EmpDetails, (c, d) => new {c, d})
                             .Where(@t => c.ID == y.ID && c.FirstName == "A" && c.LastName == "D")
                             .Select(@t => c)).Any().ToString();
            }
        }
