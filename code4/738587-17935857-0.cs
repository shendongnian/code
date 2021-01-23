    class CellType
    {
       // some fields that are interesting like
       public string Text {get;set;}
    }
    class Row {
       public List<CellType> Cells {get;set}
    }
    interface IRowExtractor
    { 
         IEnumerable<Row> Rows {get};
    }
    class GVRowExtractor : IRowExtractor
    {
       List<Rows> rows;
       public GVRowExtractor(GridView gv)
       {
            // fill Rows from gv
       }
       public IEnumerable<Row> Rows {get {return rows;}};
    }
    class DVRowExtractor : IRowExtractor ....
    void foo(IRowExtractor dv) {
      foreach(var row in dv.Rows) {
         Use(row.Cells[2].Text); // Simply read each row
     }
    }
