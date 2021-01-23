    public interface IMaster<TDetail>
        where TDetail : IDetail
    {
        List<TDetail> Details { get; }
    }
    public interface IDetail
    {
        int RecordID { get; }
        int BOMID { get; }
        bool isDeleted { get; }
        Entity.ActionMode Action { get; set; }
    }
    public class PinBOMMaster : IMaster<PinBOMDetail>
    {
        ...
    }
    public class PinBOMDetail : IDetail
    {
        ...
    }
    private List<T2> FillChildControlOnSave<T1, T2>(ref T1 objEntity, 
                                                    ref List<T1> _entityParent, 
                                                    ref List<T2> _entityDetail)
        where T1 : IMaster<T2>
        where T2 : IDetail
    {
        ...
    }
