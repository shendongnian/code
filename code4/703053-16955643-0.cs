    public class BaseDef
    {
        public int Id { get; set; }
        public override string ToString()
        {
            return Id.ToString();
        }
    }
    public class BaseView
    {
        public int Id { get; set; }
        public BaseView()
        {
        }
        public BaseView(BaseDef bd)
        {
            Id = bd.Id;
        }
        public BaseDef ToBaseDef()
        {
            return new BaseDef { Id = this.Id };
        }
        public static implicit operator BaseView(BaseDef bd)
        {
            return new BaseView(bd);
        }
        public static implicit operator BaseDef(BaseView bv)
        {
            return bv.ToBaseDef();
        }
    }
    public class DerivedDef : BaseDef
    {
        public string Name { get; set; }
        public DerivedDef()
            : base()
        {
        }
        public DerivedDef(BaseDef bd)
        {
            this.Id = bd.Id;
        }
    }
    public class DerivedView : BaseView
    {
        public string Name { get; set; }
        public DerivedView()
            : base()
        {
        }
        public DerivedView(DerivedDef dd)
            : base(dd)
        {
            Name = this.Name;
        }
        public DerivedDef ToDerivedDef()
        {
            return new DerivedDef((BaseView)this)
            {
                Name = this.Name,
            };
        }
        public static implicit operator DerivedView(DerivedDef dd)
        {
            return new DerivedView(dd);
        }
        public static implicit operator DerivedDef(DerivedView dv)
        {
            return dv.ToDerivedDef();
        }
    }
    public class SomeHelper<Tdef, Tview>
        where Tdef : BaseDef
        where Tview : BaseView
    {
        public Func<Tview, Tdef> ConvertToDef { get; set; }
        public Func<Tdef, Tview> ConvertToView { get; set; }
        public Tdef Convert(Tview vm)
        {
            if (ConvertToDef == null)
            {
                throw new ArgumentNullException("ConvertToDef uninitialized");
            }
            return ConvertToDef(vm);
        }
        public Tview Convert(Tdef dm)
        {
            if (ConvertToView == null)
            {
                throw new ArgumentNullException("ConvertToView uninitialized");
            }
            return ConvertToView(dm);
        }
    }
