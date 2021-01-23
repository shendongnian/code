        public enum myEnum
        {
            [System.Xml.Serialization.XmlEnumAttribute("1")]
            titi,
            [System.Xml.Serialization.XmlEnumAttribute("2")]
            toto
        }
        public static class myEnumExtensions
        {
            public static int toInt(this myEnum value)
            {
                MemberInfo memberInfo = typeof(myEnum).
                    GetMember(value.ToString()).FirstOrDefault();
                XmlEnumAttribute attribute = (XmlEnumAttribute) memberInfo.
                    GetCustomAttributes(typeof(XmlEnumAttribute), false).FirstOrDefault();
                return int.Parse(attribute.Name);
            }
        }
        class test
        {
            static void Main(string[] args)
            {
                int i = myEnum.titi.toInt();
            }
        }
