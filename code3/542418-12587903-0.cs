    internal RulesEngineHeaderMap()
    {
        Table("LIOEP023");
        CompositeId()
            .KeyProperty(x => x.CompanyCode, "CONO23")
            .KeyProperty(x => x.RuleID, "RLID23");
        Map(x => x.RuleGroup, "RGRP23")
            .Length(30)
            .Not.Nullable();
        Map(x => x.RuleDescription, "RLDS23")
            .Length(50)
            .Not.Nullable();
        Map(x => x.Expression, "EXPR23")
            .Length(2500)
            .Not.Nullable();
    }
