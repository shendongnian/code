    var query = from sbw in _sbwRepository.Table
                            group sbw by new
                            {
                                sbw.ShippingMethodId,
                                sbw.From,
                                sbw.To,
                                sbw.ShippingChargeAmount,
                                sbw.RegionId,
                                sbw.ItemRangeId
                            }
                                into grouping
                                select new ShippingByWeightRecord {
                                        Id = grouping.Max(sbw => sbw.Id),
                                        ShippingMethodId = grouping.Key.ShippingMethodId,
                                        From = grouping.Key.From,
                                        To = grouping.Key.To,
                                        ShippingChargeAmount = grouping.Key.ShippingChargeAmount,
                                        RegionId = grouping.Key.RegionId,
                                        ItemRangeId = grouping.Key.ItemRangeId  
                                 }; 
