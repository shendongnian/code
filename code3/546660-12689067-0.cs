    public abstract class ViewModelBase : INetworkAware
    {
    
        public abstract void SetupEvents();
    
    }
    
    public class PatientInformationViewModel : ViewModelBase
    {
        public override void SetupEvents()
        {
            //register for your events
        }
    }
