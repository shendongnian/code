    public class ActionResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
    }
    public ActionResult BackUpDatabase(string filePath)
        {
            ActionResult res = new ActionResult { Result = true };
            using (SalaryAndBenefitsEntities _context = new SalaryAndBenefitsEntities())
            {
                string command = "select db_name()";
                string databaseName = _context.Database.SqlQuery(typeof(string), command).ToListAsync().Result.FirstOrDefault().ToString();
                string backUpQuery = BackUpCommand(databaseName, filePath);
                var result = _context.Database.SqlQuery<List<string>>(backUpQuery).ToList();
                if (result.Count() > 0)
                {
                    res.Result = false;
                    result.ForEach(x =>
                    {
                        res.Message += x.ToString();
                    });
                }
                return res;
            }
        }
      
