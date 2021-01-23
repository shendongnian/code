    namespace BurnIn.UI.Modules.Operations.ViewModels
    {
    public class SlotInfo
    {
        public int SlotNumber;
        public string BibName;
    }
    public class OvenViewModel : OvenViewModelBase
    {
        List<SlotInfo> m_BibList = new List<SlotInfo>();
        public List<SlotInfo> BibList
        {
            get { return m_BibList; }
        }
