    var com = 
        from c in MyContext.tblService 
        join sce in MyContext.tblServiceExtension on c.ServiceExtensionCode equals sce.ServiceExtensionCode
        join sc in MyContext.tblServiceContract on sce.ServiceContractCode equals sc.ContractCode
        group sc by c.Period into comG
        select new
        {
            PeriodNumber = comG.Key,
            Group = comG,
        }; // no ToArray
    var code =
        from c in com
        join p in per on c.PeriodNumber equals p.PeriodNumber
        select new
        {
            p.Code, 
            c.Group
        }; // no ToArray
    var results = 
        (from p in MyContext.tblPaySomething
         join cae in MyContext.tblSomethingElse on p.PaymentCode equals cae.PaymentCode
         join ca in MyContext.tblAnothThing on cae.SomeCode equals ca.SomeCode
         join cg in MyContext.Codes.GroupBy(c => c.Code, c => c.Code) on cg.Key equals p.Code
         where cg.Contains(ca.ContractCode.Value)
         select new
         {
             p.ContractPeriodCode,
             p.DomainSetExtensionCode,
             p.IsFlagged,
             p.Narrative,
             p.PaymentCode,
             ca.BookingCode,
             cae.Status
         })
        .ToList();
