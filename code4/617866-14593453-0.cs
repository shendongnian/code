    using FluentNHibernate.Automapping.Alterations;
    public class EntityOverride : IAutoMappingOverride<Entity>
    {
        public void Override(AutoMapping<Entity> mapping)
        {
             mapping.Component(x => x.Component, c => 
             {
                   c.Map(Reveal.Member<Component>("fieldName1"),"columnName1");
                   c.Map(Reveal.Member<Component>("fieldName2"),"columnName2");
                   c.Map(Reveal.Member<Component>("fieldName3"),"columnName3");
             });
        }
    }
