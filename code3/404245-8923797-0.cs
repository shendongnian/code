    public class ClassB
    {
        private ClassA = new ClassA();
        public int? shouldBeInteger
        {
            get
            {
                return (this.ClassA._shouldBeInteger != null)
                    ? Convert.ToInt32(Convert.ToDouble(this.ClassA._shouldBeInteger))
                    : new int?();
           }
            set
            {
                this.ClassA._shouldBeInteger = Convert.ToString(value);
            }
        } 
    }
