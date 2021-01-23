    namespace blah.blah.blah
    [Serializable]
    public class Blah : FromBlah
    [NonSerialized]
    private List<SelectListItem> _mySelectList;
    public List<SelectListItem> MySelectList
    {
        get { return _mySelectList; }
        set { _mySelectList= value; }
    }
