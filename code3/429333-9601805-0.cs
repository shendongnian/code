    //this namespace MUST match the namespace of your entity model.
    namespace Your.Entity.Model.Namespace
    {
        public partial class Flag
        {
            public override bool Equals(object obj)
            {
                var item = obj as Flag;
    
                if (item == null)
                {
                    return false;
                }
    
                return this.Id.Equals(item.Id);
            }
    
            public override int GetHashCode()
            {
                return this.Id.GetHashCode();
            }
        }
    }
