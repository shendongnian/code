    public class JoinedSubclassIdConvention : IJoinedSubclassConvention, 
         IJoinedSubclassConventionAcceptance
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.Key.Column(instance.EntityType.Name + "Id");
        }
    
        public void Accept(IAcceptanceCriteria<IJoinedSubclassInspector> criteria)
        {
            criteria.Expect(x => x.EntityType == typeof(TaskDownload));
        }
    }
