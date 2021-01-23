    public class Screen { }
    public abstract class EntityBaseCore
    {    }
    public abstract class EntityBase : EntityBaseCore
    {    }
    public partial class AdmSite : EntityBase
    {    }
    public abstract class ViewModelSecurityBase<T> : Screen where T : EntityBaseCore
    {    }
    public abstract class EditorViewModelBase<T> : ViewModelSecurityBase<T> where T : EntityBaseCore
    {    }
    public class SiteViewModel : EditorViewModelBase<AdmSite>
    {    }
