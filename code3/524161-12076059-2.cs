    class ChildResult
    {
       public int PID { get; set; }
       public int? CID { get; set; }
       public string Text { get; set; }
    }
    lParent.SelectMany(p => p.Childs.Any() ?
      p.Childs.Select(c => new ChildResult() { PID = c.PID, CID = c.CID, Text = c.Text }) :
      new [] { new ChildResult() { PID = p.PID, CID = null, Text = "[[Empty]]" } } );
