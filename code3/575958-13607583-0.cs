    class BasePointsRuleMap : IAutoMappingOverride<UniversalProgram>
    {
        public void Override(AutoMapping<UniversalProgram> mapping)
        {
            mapping.HasMany(x => x.AmountPointsRules).Where("basepointstype='AmountPointsRule'");
            mapping.HasMany(x => x.TresholdPointsRules).Where("basepointstype='TresholdPointsRule'");
        }
    }
