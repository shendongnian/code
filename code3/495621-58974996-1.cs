            var query = _orders.Selecting(o => 
                    new ComplexRowViewModel()
                               {Isin = o.Isin,
                                Name = o.Isin,
                                GermanSymbol = o.Exchange,
                                PrimarySymbol = o.State.ToString()};
            GridData = query;
