        public class CustomizedDataType
        {
            private int field1;
            private string field2;
            public CustomizedDataType(int field1,string field2)
            {
                this.field1 = field1;
                this.field2 = field2;
            }
            public override bool Equals(object obj)
            {
                CustomizedDataType dataType = obj as CustomizedDataType;
                if (this.field1 == dataType.field1 && this.field2 == dataType.field2)
                {
                    return true;
                }
                return false;
            }
            public override int GetHashCode()
            {
                return (this.field1.GetHashCode() + this.field2.GetHashCode());
            }
