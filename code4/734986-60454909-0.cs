        public class DtoEnumAttribute : Attribute
        {
            public DtoSelection Enum { get; set; }
            public DtoEnumAttribute(DtoSelection enum)
            {
                this.Enum = enum;
            }
         }
