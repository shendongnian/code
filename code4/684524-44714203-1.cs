            public void Get_Value_Of_Property()
        {
            var testObject = new ReflectedType
            {
                AReferenceType_No_Attributes = new object(),
                Int32WithRange1_10 = 5,
                String_Requires = "Test String"
            };
            var result = testObject.GetType().GetProperty("String_Requires").GetPropertyValue(testObject).DynamicCast<string>();
            result.Should().Be(testObject.String_Requires);
        }
      public void Set_Value_Of_Property()
            {
                var testObject = new ReflectedType
                {
                    AReferenceType_No_Attributes = new object(),
                    Int32WithRange1_10 = 5,
                    String_Requires = "Test String"
                };
    
                testObject.GetType().GetProperty("String_Requires").SetPropertyValue(testObject, "MAGIC");
    
                testObject.String_Requires.Should().Be("MAGIC");
            }
