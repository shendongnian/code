    namespace BurnIn.UI.Modules.Operations.ViewModels
    {
    public class SlotInfo
    {
        public int SlotNumber;
        public string BibName;
    }
    public class OvenViewModel : OvenViewModelBase
    {
        var m_BibList = new List<SlotInfo>();
        public IList<SlotInfo> BibList
        {
            get { return m_BibList; }
        }
