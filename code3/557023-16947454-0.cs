        using System.Reflection;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        public static string CodeBase(
            TestContext testContext)
        {
            System.Type t = testContext.GetType();
            FieldInfo field = t.GetField("m_test", BindingFlags.NonPublic | BindingFlags.Instance);
            object fieldValue = field.GetValue(testContext);
            t = fieldValue.GetType();
            PropertyInfo property = fieldValue.GetType().GetProperty("CodeBase");
            return (string)property.GetValue(fieldValue, null);
        }
