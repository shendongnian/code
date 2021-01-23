            PeriodicityEvent pEvent = new PeriodicityEvent
            {
                Name = "record1",
                DateStart = new DateTime(2012, 02, 02),
                DateEnd = new DateTime(2012, 03, 31),
                PeriodicityType = 1,
                Periodicity = 2
            };
            DateTime baseDate = new DateTime(2012, 02, 01);
            for (int i = 0; i < 30; i++)
	    {
                DateTime testDate = baseDate.AddDays(i);
                if (dateEvaluators[pEvent.PeriodicityType](pEvent.DateStart, pEvent.DateEnd, testDate, pEvent.Periodicity))
                {
                    Console.WriteLine("{0} is in", testDate.ToString("dd MMM"));
                }
                else
                {
                    Console.WriteLine("{0} is out", testDate.ToString("dd MMM"));
                }
	   }
