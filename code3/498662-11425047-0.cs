    class PeopleModel {
      public int PeopleID { get; set; }
      public string Name  { get; set; }
      /* .. additional fields or values .. */
    }
    class ThingsModel {
      public int ThingsID { get; set; }
      public string Name  { get; set; }
      /* .. additional fields or values .. */
    }
    class PeopleHasThing {
      public int PersonID { get; set; }
      public int ThingsID { get; set; }
    }
