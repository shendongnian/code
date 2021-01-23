    public interface IThingService
    {
        Thing GetThing(int id);
        ThingCreationResponse AddThing(ThingCreationRequest request);
    }
