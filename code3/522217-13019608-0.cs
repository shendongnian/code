        internal class MyObject
        {
          internal string Description { get; set; }
          internal int Stock { get; set; }
          internal int DaysSinceLastCount { get; set; }
          internal double TotalValue { get; set; }
          internal bool IsUpToDate { get; set; }
          internal bool IsUnableToBeSet    {        get { return Stock==5; }    }
         }
