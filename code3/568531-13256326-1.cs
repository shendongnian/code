    public class NameAndDone {
      public string document_Name { get; set; }
      public bool document_Done { get; set; }
    }
    var doc = from c in projectE.Person_Documents
              join cw in projectE.Documents on c.Document_Id equals cw.Document_Id
              where c.Person_Id == 150
              select new NameAndDone {
                cw.document_Name,
                c.document_Done
              };
