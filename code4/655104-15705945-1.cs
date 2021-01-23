	class TestClass	
	{
        private void Test()
        {
            TestInstance();
            TestStatic();
        }
        private void TestInstance()
        {
            var eventClass = new EventClass();
            eventClass.InvokeDelegate("InstanceEventRaiseDelegate");
            eventClass.AddHandler("InstanceEvent", parameters =>
                {
                    return true;
                });
            eventClass.AddHandler("InstanceEventRaiseDelegate", parameters =>
            {
                return true;
            });
            eventClass.InvokeDelegate("InstanceEventRaiseDelegate");
            
            eventClass.AssignHandler("InstanceEventRaiseDelegate", parameters =>
            {
                return true;
            });
            eventClass.InvokeDelegate("InstanceEventRaiseDelegate");
        }
        private void TestStatic()
        {
            typeof(EventClass).InvokeDelegate("StaticEventRaiseDelegate");
            typeof(EventClass).AddHandler("StaticEvent", parameters =>
            {
                return true;
            });
            typeof(EventClass).AddHandler("StaticEventRaiseDelegate", parameters =>
            {
                return true;
            });
            typeof(EventClass).InvokeDelegate("StaticEventRaiseDelegate");
            typeof(EventClass).AssignHandler("StaticEventRaiseDelegate", parameters =>
            {
                return true;
            });
            typeof(EventClass).InvokeDelegate("StaticEventRaiseDelegate");
        }
        public class EventClass
        {
            #region Instance
            public EventClass()
            {
                InstanceEventRaiseDelegate = OnInstanceEvent;
            }
            public Action InstanceEventRaiseDelegate;
            public event EventHandler InstanceEvent;
            public void OnInstanceEvent()
            {
                if (InstanceEvent != null)
                    InstanceEvent(this, EventArgs.Empty);
            }
            #endregion
            #region Static
            static EventClass()
            {
                StaticEventRaiseDelegate = OnStaticEvent;
            }
            public static Action StaticEventRaiseDelegate;
            public static event EventHandler StaticEvent;
            public static void OnStaticEvent()
            {
                if (StaticEvent != null)
                    StaticEvent(null, EventArgs.Empty);
            }
            #endregion
        }
    }
	
