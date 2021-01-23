    namespace Microsoft.VisualBasic
    {
      [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
      public sealed class VBFixedStringAttribute : Attribute
      {
        private int m_Length;
        public int Length
        {
          get
          {
            return this.m_Length;
          }
        }
        public VBFixedStringAttribute(int Length)
        {
           if (Length < 1 || Length > (int) short.MaxValue)
                throw new ArgumentException(Utils.GetResourceString("Invalid_VBFixedString"));
           this.m_Length = Length;
        }
      }
    }
