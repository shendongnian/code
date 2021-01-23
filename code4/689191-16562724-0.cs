    public class GlobalSettings
    {
        public virtual bool A { get; set; }
    }
    public class UserSettings : GlobalSettings
    {
        public override bool A 
        { 
            get 
            { 
                return base.A  ? base.A : A;
            }
            set
            {
                this.A = value;
            }
        }
    }
