    Intuit.Ipp.Data.Qbo.InvoiceLine  InvLine  = new Intuit.Ipp.Data.Qbo.InvoiceLine();
    InvLine.Desc = "DEMO";
    InvLine.Amount = 400.0m;
    InvLine.AmountSpecified = true;
    InvLine.ItemsElementName = new Intuit.Ipp.Data.Qbo.ItemsChoiceType2[]
                                    {
                                        Intuit.Ipp.Data.Qbo.ItemsChoiceType2.ItemId,
                                        Intuit.Ipp.Data.Qbo.ItemsChoiceType2.Qty,
                                        Intuit.Ipp.Data.Qbo.ItemsChoiceType2.UnitPrice
                                    };
    InvLine.Items = new object[]
                        {
                            new IdType(){idDomain=idDomainEnum.QB, Value="17"},
                            4m,
                            100m
                        }; 
