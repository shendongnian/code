            public class MyFileLayout
            {
                [FieldFixedLength(2)]
                public string prefix;
                [FieldFixedLength(12)]
                public string customerName;
            }
            Type type = typeof(MyFileLayout);
            FieldInfo fieldInfo = type.GetField("prefix");
            object[] attributes = fieldInfo.GetCustomAttributes(false);
            FieldFixedLengthAttribute attribute = (FieldFixedLengthAttribute)attributes.FirstOrDefault(item => item is FieldFixedLengthAttribute);
            if (attribute != null)
            {
                // read info
            }
