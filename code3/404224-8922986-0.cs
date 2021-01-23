    public class CustomConfigurationSection : ConfigurationSection
        {
          [ConfigurationProperty("myEnumProperty", DefaultValue = MyEnum.Item1, IsRequired = true)]
          public MyEnum SomeProperty
          {
            get
            {
              MyEnum tmp;
              return Enum.TryParse((string)this["myEnumProperty"],true,out tmp)?tmp:MyEnum.Item1;
            }
            set
            { this["myEnumProperty"] = value; }
          }
        }
