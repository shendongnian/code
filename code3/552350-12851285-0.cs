    public class EventProcessorMapping : ConfigurationElement
    {
        [ConfigurationProperty("event", IsRequired = true)]
        public string Event
        {
            get
            {
                return this["event"] as string;
            }
        }
        [ConfigurationProperty("processor", IsRequired = true)]
        public string Processor
        {
            get
            {
                return this["processor"] as string;
            }
        }
    }
    [ConfigurationCollection(typeof(EventProcessorMapping), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class EventProcessors : ConfigurationElementCollection
    {
        public EventProcessorMapping this[int index]
        {
            get
            {
                return BaseGet(index) as EventProcessorMapping;
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new EventProcessorMapping();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EventProcessorMapping)element).Event;
        }
    }
    public class RegisterEventProcessorsConfig : ConfigurationSection
    {
        public static RegisterEventProcessorsConfig GetConfig()
        {
            return (RegisterEventProcessorsConfig)ConfigurationManager.GetSection("RegisterEventProcessors") ?? new RegisterEventProcessorsConfig();
        }
        [ConfigurationProperty("EventProcessors")]
        public EventProcessors EventProcessors
        {
            get
            {
                var o = this["EventProcessors"];
                return o as EventProcessors;
            }
        }
    }
