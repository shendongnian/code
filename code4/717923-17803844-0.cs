    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool IsDiscriminated(System.Type type)
        {
            var types = new System.Type[] { typeof(Stop), typeof(WorkStop) };
            return base.IsDiscriminated(type) || types.Contains(type);
        }
