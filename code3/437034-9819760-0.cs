    Id<int>(x => x.IdCessionsLignes, map =>
    {
        map.Column("SCESL_SCESID")
           .Generator(NHibernate.Mapping.ByCode.Generators.Identity);
    });
