    var query = from l in lista
                group l by l.Fecha into fetchaGroup
                select new
                {
                    Fecha = fetchaGroup.Key,
                    Count = fetchaGroup.Count()
                    ,FetchaGroup = (from fg in fetchaGroup
                                       group fg by fg.Nbanco into NbancoGroup
                                       select new
                                       {
                                           Nbanco = NbancoGroup.Key,
                                           NbancoGroup = (from ng in NbancoGroup
                                                          group ng by ng.Ngrupo into NgrupoGroup
                                                          select new { Ngrupo = NgrupoGroup.Key, NgrupoGroup }
                                                        )
                                       }
                                    )
                }
                ;
    foreach (var g in query)
    {
        Console.WriteLine("{0} ({1})", g.Fecha, g.Count);
        foreach (var fg in g.FetchaGroup)
        {
            Console.WriteLine("\t{0}", fg.Nbanco);
            foreach (var ng in fg.NbancoGroup)
            {
                Console.WriteLine("\t\t{0} {1}", ng.Ngrupo, ng.NgrupoGroup.Sum(ngg => ngg.Monto));
                if (ng.NgrupoGroup.Count() > 1)
                {
                    foreach (var ngg in ng.NgrupoGroup)
                    {
                        Console.WriteLine("\t\t\t{0} {1}", ngg.Npersona, ngg.Monto);
                    }
                }
            }
        }
    }
