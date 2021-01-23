    [Guid("C25D485B-F7DE-4F1C-99FE-FFAF5A219B77"),
    ClassInterface(ClassInterfaceType.None)]
    public class TimeSeriesPoint
    {
        public string Date { get; set; }
        public float Value { get; set; }
    }
    [Guid("FA6F70DD-CDD0-4FF3-94BA-E2B94E68321D"),
    InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IDataHelper
    {
        //RCOMServerLib.IStatConnector Connector { set; }
        string Text { set; }
        void DoCallback();
