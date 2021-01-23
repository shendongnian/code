     class AggregatedReportField {
         public string FieldName { get; set; }
         public decimal FieldValue { get; set; }
     }
     class ItemReportDTO {
         
         public Dictionary<string, AggregatedReportField> ReportFields { get; private set; }
         public ItemReportDTO()
         {
             ReportFields = new Dictionary<string, AggregatedReportField>();
         }
         public void Add(AggregatedReportField field)
         {
             if (!ReportFields.ContainsKey(fieldl.FieldName))
                  ReportFields.Add(field.FieldName, field);
         }
     }
