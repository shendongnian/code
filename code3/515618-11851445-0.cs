    public abstract class OwlRelation : IOwlRelation
    {
        // Implement infrastructure common to all relation types
    }
    public SubclassOwlRelation : OwlRelation
    {
        // Implement things specific to Subclass-relations
    }
    public HasArmOwlRelation : OwlRelation
    {
        // Implement things specific to HasArm-relations
    }
    ...
