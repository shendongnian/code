    public class ExampleLog  {
        public virtual long Id   { get; set; }
        public virtual string MessageText { get; set; }
    }
    [TestMethod]
        public void ExampleLogTest() {
            var e1 = new ExampleLog();
            e1.MessageText = "example1";
            var e2 = new ExampleLog();
            e2.MessageText = "example2";
            _context.Set<ExampleLog>().Add(e1);
            _context.Set<ExampleLog>().Add(e2);
         var res =   _context.SaveChanges();
          Debug.WriteLine("result expected 2->" + res.ToString());
        }
