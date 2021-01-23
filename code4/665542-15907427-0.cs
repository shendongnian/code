    var test = (from c in context.ConsumptionSet
                join pi in context.PropertiesInstanceSet on c.PropertiesInstanceID equals pi.PropertiesInstanceID
                join ep in context.EquipmentPropertiesSet on pi.EquipmentPropertiesID equals ep.EquipmentPropertiesID
                where (ep.EquipmentID == equipmentId && pi.ProprietesName == ProprietesName.Energy && c.Date <= DateTime.Today && c.Date >= EntityFunctions.AddDays(DateTime.Today, -7))
                group c by SqlFunctions.DatePart("weekday", c.Date) into grp
                select new
                {
                   test = grp.Key,
                   value = (from c2 in grp select c2.Value).Max()
    
                }).ToList();
