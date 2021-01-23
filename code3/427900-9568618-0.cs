    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    /// <summary>
    /// Summary description for CellInfoRepository
    /// </summary>
    public class CellProducer
    {
        System.Collections.Generic.List<Cell> cells = new List<Cell>();
        Random random = new Random();
    
        public CellProducer()
        {
            cells.Add(new Cell { InstrumentName = "גיטרה", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "עוד", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "סיטאר", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "כינור", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "צ'לו", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "ויולה", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "נבל", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "בנג'ו", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "תופים", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "מצילה", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "שליש", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "קסטנייטה", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "פעמוניה", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "קסילופון", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "טמבורין", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "פעמוני רוח", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "קרן יער", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "בריטון", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "טרומבון", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "טובה", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "סקסופון", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "חליל", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "קלרינט", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "משרוקית", InstrumentFamily = 3, myPlayer = 0 });
        }
    
        public Cell ProduceNextCell()
        {
            return cells[random.Next(cells.Count)];
        }
    }
