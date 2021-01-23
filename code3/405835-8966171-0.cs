    db.SA_BamaType
                .AsEnumerable()
                .Select(b => new BamaTypeModel()
                {
                    id = b.p_bamatype,
                    bamatypeNames = new Dictionary<string, string>
                    {
                        { "NL", b.bamatypeafdrukNL },
                        { "FR", b.bamatypeafdrukFR },
                        { "EN", b.bamatypeafdrukEN }
                    }
                }).ToList();
