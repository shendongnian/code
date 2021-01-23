    var autoscombined = from f in fileInv
        join d in dbInv
        on new {f.DealerCode, f.ModelCode, f.ModelYear, f.ExteriorCodeCode, f.InteriorColorCode} 
            equals new {d.DealerCode, d.ModelCode, d.ModelYear, d.ExteriorCodeCode, d.InteriorColorCode}
        select new IDiscObj {
            DealerCode = f.DealerCode,
            DealershipName = d.DealershipName,
            ModelCode = f.ModelCode,
            ModelYear = f.ModelYear,
            ExteriorCodeCode = f.ExteriorCodeCode,
            InteriorColorCode = f.InteriorColorCode,
            FileVehicleCount = f.FileVehicleCount,
            DbVehicleCount = d.DbVehicleCount
        };
