    public partial class MyEntity
    {
         public double MyComputedValue
         {
            get
            {
                return this.Score/this.Value;
            }
         }
    }
