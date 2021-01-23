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
        int index = -1;
    
        public CellProducer()
        {
            cells.Add(new Cell { InstrumentName = "?????", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "???", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "?????", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "?????", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "?'??", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "?????", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "???", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "???'?", InstrumentFamily = 1, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "?????", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "?????", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "????", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "????????", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "???????", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "????????", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "???????", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "?????? ???", InstrumentFamily = 2, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "??? ???", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "??????", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "???????", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "????", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "???????", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "????", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "??????", InstrumentFamily = 3, myPlayer = 0 });
            cells.Add(new Cell { InstrumentName = "???????", InstrumentFamily = 3, myPlayer = 0 });
        }
    
        public Cell ProduceNextCell()
        {
    		index++;
    		if(index>cells.length){
    			index = 0;
            return cells[index];
        }
    }
