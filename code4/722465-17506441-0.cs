    public class Entry {
       public int Id { get; set; }
       public int? ParentId { get; set; }
       public DateTime Date { get; set; }   
    };
    
     var list = new List<Entry> {
      new Entry{ Id = 1, ParentId = null, Date = new DateTime(2013, 7, 1) },
      new Entry{ Id = 2, ParentId = null, Date = new DateTime(2013, 7, 1) },
      new Entry{ Id = 3, ParentId = null, Date = new DateTime(2013, 7, 1) },
      new Entry{ Id = 4, ParentId = 1, Date = new DateTime(2013, 7, 2) },
      new Entry{ Id = 5, ParentId = 2, Date = new DateTime(2013, 7, 3) },
      new Entry{ Id = 6, ParentId = 2, Date = new DateTime(2013, 7, 4) },
      new Entry{ Id = 7, ParentId = 1, Date = new DateTime(2013, 7, 5) }
    };
