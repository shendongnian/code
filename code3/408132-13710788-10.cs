    #region Assembly Microsoft.VisualStudio.TestPlatform.UnitTestFramework.dll, v11.0.0.0
    // C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0\ExtensionSDKs\MSTestFramework\11.0\References\CommonConfiguration\neutral\Microsoft.VisualStudio.TestPlatform.UnitTestFramework.dll
    #endregion
    using System;
    namespace Microsoft.VisualStudio.TestPlatform.UnitTestFramework
    {
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public class DataTestMethodAttribute : TestMethodAttribute
        {
            public DataTestMethodAttribute();
    
            public override TestResult[] Execute(ITestMethod testMethod);
        }
    }
