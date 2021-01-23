    public interface IXmlRepository
    {
       //irrelevant stuff removed
       event EventHandler TraceEventHandler;
    }
    public class XmlPanelRepository : IXmlRepository
    {
        public delegate void EventHandler(string parameter1, string parameter2);
    
        public event EventHandler TraceEventHandler;
        
        public XmlPanelRepository()
        {
            var panelCom = new PanelCom(); // this is a COM object that connects to a device
            // when something happens in the COM object it reports it.
            panelCom.Trace += panelCom_Trace; 
        }
        void panelCom_Trace(string message)
        {
            if (EventHandler != null)
              EventHandler("Event was hit, here's the message:", message);
        }
    }
    public interface IXmlConfigurationService
    {
        //irrelevant stuff removed
    }
    public class XmlConfigurationService : IXmlConfigurationService
    {
        public XmlConfigurationService(IXmlRepository configurationRepository)
        {
            _configurationRepository.TraceEventHandler += ConfigurationRepository_EventHandler;
        }
        void ConfigurationRepository_EventHandler(string parameter1, string parameter2);)
        {
            // Do something with your parameters.
            Response.Write(parameter1 + parameter2);
        }
    }
