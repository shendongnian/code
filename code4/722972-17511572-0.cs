    Mapper.CreateMap<List<KeyValuePair<string, string>>, QuantityRestriction>()
            .AfterMap((src, qr) =>
            {
                switch (src[0].Value)
                {
                    case "Quantity":
                        switch (src[1].Key)
                        {
                            case "Max":
                                qr.MaxQuantity = Int32.Parse(src[1].Value);
                                break;
                            case "Min":
                                qr.MinQuantity = Int32.Parse(src[1].Value);
                                break;
                        }
                        return;
                    // case "Amount"
                    // case "Weight"
                }
            });
