    public class MyUserControl
    ....
    
    public bool IsColumn1ReadOnly{
        get{ return v_uc1.v_datagrid.Columns[1].IsReadOnly;}
        set {return v_uc1.v_datagrid.Columns[1].IsReadOnly = value;}
    }
