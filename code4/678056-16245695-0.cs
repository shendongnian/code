    public class EventData {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Line5 { get; set; }
    }
    ...
    var results = new List<EventData>();
    // loop through lines in file
     while ( objInput.Peek() > -1 &&
        m_intNumberOfEvents < 10 )
     {
        intFileDay = Int32.Parse( strLine ); // extract day
        // if event scheduled for specified day,
        // store information
        if ( intFileDay == intChosenDay )
        {
            var foo = new EventData();
            foo.Line1 = strLine;
            foo.Line2 = objInput.ReadLine();
            foo.Line3 = objInput.ReadLine();
            foo.Line4 = objInput.ReadLine();
            foo.Line5 = objInput.ReadLine();
            results.Add(foo);
            m_intNumberOfEvents++;
        }
        else
        {
           // skip to next event in file
           for ( intLineNumbers = 0; intLineNumbers <= 3;
              intLineNumbers++ )
              strLine = objInput.ReadLine();
        }
        // read day of next event in file
        strLine = objInput.ReadLine();
     } // end while
