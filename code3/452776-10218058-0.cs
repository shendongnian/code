    var allFs = fRepository.GetFs().Select(f => new {f.Name, f.SerialNumber}).ToList();
    
    int year = Convert.ToInt32(billingYear);
    int month = Convert.ToInt32(billingMonth);
    
    var allEs = eRepository.GetEs().Where(e.Year == year && e.Month == month).Select(e => new {e.FSerialNumber, e.IntCustID}).ToList();
    
    
    var EFs = from c in allFs
        join e in allEs on c.SerialNumber equals e.FSerialNumber
        select new EReport
        {
            FSerialNumber = c.SerialNumber,
            FName = c.Name,
            IntCustID = Convert.ToInt32(e.IntCustID),
            TotalECases = 0,
            TotalPrice = "$0"
        };
