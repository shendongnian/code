    new Select("SalesRep, Location, InvoiceNumber, PONumber, POReceivedOn, SurgeryDate, Surgeon")
                        .From(VSalesRepCommissionGrouped.Schema)
                        .WhereExpression("SurgeryDate").IsGreaterThanOrEqualTo(BeginDate)
                                  .And("SurgeryDate").IsLessThanOrEqualTo(EndDate)
                         .OrExpression("SurgeryDate").IsGreaterThanOrEqualTo(BeginDate.AddMonths(-1))
                                  .And("SurgeryDate").IsLessThanOrEqualTo(EndDate.AddMonths(-1))
                                  .And("POReceivedOn").IsGreaterThanOrEqualTo(BeginDate)
                        .AndExpression("UserID").In(new[] { 5, 6, 20 })
                        .OrderAsc("SurgeryDate");
