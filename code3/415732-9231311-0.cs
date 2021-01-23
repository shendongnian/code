    public class ViewModelBase : IViewModel {
        public string InformationForMasterPage{get;set;}
    }
    public class ViewModelHomePage : ViewModelBase{
        public string SomeInformationNotNeededForMasterPage{get;set;}
    }
    public interface IViewModel{
        public string InformationForMasterPage{get;set;}
    }
