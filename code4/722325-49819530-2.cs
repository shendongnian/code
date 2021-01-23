    public class TestClass
    {
        public bool TestMethod1()
        {
            bool Result = false;
            Enum l_Value = TEST_ENUM.TEST_VALUE_1;
            Enum l_Check_Value = TEST_ENUM.TEST_VALUE_1;
            Result = l_Value == l_Check_Value;
            return Result;
        }
        public bool TestMethod2()
        {
            bool Result = false;
            TEST_ENUM l_Value = TEST_ENUM.TEST_VALUE_1;
            TEST_ENUM l_Check_Value = TEST_ENUM.TEST_VALUE_1;
            Result = l_Value == l_Check_Value;
            return Result;
        }
        public bool TestMethod3()
        {
            bool Result = false;
            Enum l_Value = TEST_ENUM.TEST_VALUE_1;
            Enum l_Check_Value = TEST_ENUM.TEST_VALUE_1;
            Result = l_Value.Equals(l_Check_Value);
            return Result;
        }
        public enum TEST_ENUM
        {
            TEST_VALUE_1,
            TEST_VALUE_2,
            TEST_VALUE_3
        }
    }
