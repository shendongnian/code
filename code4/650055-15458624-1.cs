        class EnumMemberAttribute : Attribute
        {
            private String name;
    
            public String Name
            {
                get { return this.name; }
                set { this.name = value; }
            }
    
            public EnumMemberAttribute(String name)
            {
                this.name = name;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Type type = typeof(PersonGender);
                MemberInfo[] members = type.GetMember(PersonGender.NonStated.ToString());
                Object[] attributes = members[0].GetCustomAttributes(typeof(EnumMemberAttribute),
                    false);
                Console.WriteLine(((EnumMemberAttribute)attributes[0]).Name);            
            }
        } 
