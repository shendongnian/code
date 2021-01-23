    interface IAssignment
    {
    }
    interface IRepo<out T> where T : IAssignment
    {
        T GetAssignmentRecord(int UserId, int BatchId);
        IEnumerable<T> GetAssignmentRecords(int UserId);
    }
    class AssignmentRecord : IAssignment
    {
    }
    class AssignmentWeb : IAssignment
    {
    }
    class RepoDb : IRepo<AssignmentRecord>
    {
        public AssignmentRecord GetAssignmentRecord(int UserId, int BatchId)
        {
            //using(var db = new MyDbContext())
            //{
            //    return db.Assignment.Where(c => c.UserId == UserId && c.BatchId == BatchId && c.Assigned).First();
            //}
            return new AssignmentRecord();
        }
        public IEnumerable<AssignmentRecord> GetAssignmentRecords(int UserId)
        {
            //using(var db = new MyDbContext())
            //{
            //    return db.Assignment.Where(c => c.UserId == UserId && c.BatchId == BatchId && c.Assigned);
            //}
            return new List<AssignmentRecord> 
                {
                    new AssignmentRecord(),
                    new AssignmentRecord(),
                    new AssignmentRecord(),
                    new AssignmentRecord(),
                    new AssignmentRecord(),
                    new AssignmentRecord(),
                    new AssignmentRecord(),
                    new AssignmentRecord(),
                };
        }
    }
    class RepoWeb : IRepo<AssignmentWeb>
    {
        public AssignmentWeb GetAssignmentRecord(int UserId, int BatchId)
        {
            // fetch it from some web service...
            return new AssignmentWeb();
        }
        public IEnumerable<AssignmentWeb> GetAssignmentRecords(int UserId)
        {
            //using(var db = new MyDbContext())
            //{
            //    return db.Assignment.Where(c => c.UserId == UserId && c.BatchId == BatchId && c.Assigned);
            //}
            return new List<AssignmentWeb> 
                {
                    new AssignmentWeb(),
                    new AssignmentWeb(),
                    new AssignmentWeb(),
                };
        }
    }
    class MYController
    {
        public IRepo<IAssignment> Repository { get; set; } // you can inject this e.g. DI
        public IAssignment GetAssignment(int userid, int batchid)
        {
            return Repository.GetAssignmentRecord(userid, batchid);
        }
        public IEnumerable<IAssignment> GetAllAssignments(int userid)
        {
            return Repository.GetAssignmentRecords(userid);
        }
    }
    class ProgramAssignment
    {
        static void Main(string[] args)
        {
            try
            {
                var controller = new MYController();
                controller.Repository = new RepoDb();
                IAssignment assignment = controller.GetAssignment(0, 0);
                IEnumerable<IAssignment> all = controller.GetAllAssignments(0);
                controller.Repository = new RepoWeb();
                assignment = controller.GetAssignment(0, 0);
                all = controller.GetAllAssignments(0);
            }
            catch
            {
                Console.WriteLine("");
            }
        }
    }
