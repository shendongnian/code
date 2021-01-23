    class Decade {
  
      public int StartYear { get; private set; }
      public int EndYear { get { return StartYear + 9; } }
      public Decade(int startYear) {
        StartYear = startYear;
      }
      public bool Includes(DateTime date) {
        return StartYear <= date.Year && date.Year <= EndYear;
      }
    }
