    public class JournalsController : Controller
    {
        private readonly IJournalsRespository _journalsDb;
    
        public JournalsController(IJournalsRepository journalsDb)
        {
            _journalsDb = journalsDb
        }
    
        [HttpPost]
        public ActionResult Create(int journalId, string text)
        {
            JournalEntry journalentry = new JournalEntry();
            journalentry.Text = text;
            if (ModelState.IsValid)
            {
                var journal = _journalsDb.FindJournal(journalId);               
                journalentry.Journal = journal;                
                _journalsDb.Add(journalentry);
                _journalsDb.SaveChanges();
            }
            return View(journalentry);
        }
    }
