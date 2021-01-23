    public interface IPlugIn
    {
        void Show(Panel paneldynamic, String id, List<EventActions> eventList);
        void Hide(Panel paneldynamic, String id, List<EventActions> eventList);
        void Validate(Panel paneldynamic, String id, List<EventActions> eventList);
    }
