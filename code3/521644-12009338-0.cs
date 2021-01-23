    class DispatchCall {
      [CsvColumn(0)]
      public Int32 AccountId { get; set; }
      [CsvColumn(1)]
      public String WorkOrder { get; set; }
      [CsvColumn(3, Format = "yyyy-MM-dd")]
      public DateTime Date { get; set; }
    }
