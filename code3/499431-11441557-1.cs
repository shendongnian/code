    using System;
    using System.Text;
    using NUnit.Core.Extensibility;
    using NUnit.Core;
    
    namespace YourNUnitAddIns
    {
        /// <summary>
        /// Coleta informacoes da execucao do NUnit.
        /// </summary>
        [NUnitAddin(
            Name="CollectNUnitFailAddIn",
            Description="do something",
            Type=ExtensionType.Core)]
        public class CollectNUnitFailAddIn : IAddin, EventListener
        {
            #region IAddin Members
    
            public bool Install(IExtensionHost host)
            {    
                IExtensionPoint suiteBuilders = host.GetExtensionPoint("SuiteBuilders");
                IExtensionPoint testBuilders = host.GetExtensionPoint("TestCaseBuilders");
                IExtensionPoint events = host.GetExtensionPoint("EventListeners");
    
                if (events == null)
                    return false;
    
                events.Install(this);
    
                return true;
            }
    
            #endregion
    
            #region EventListener Members
    
            public void RunFinished(Exception exception)
            {
                //do something here.
            }
    
            public void RunFinished(TestResult result)
            {
                //do something here.
            }
    
            public void RunStarted(string name, int testCount)
            {
                //do something here.
            }
    
            public void SuiteFinished(TestResult result)
            {
                //do something here.
            }
    
            public void SuiteStarted(TestName testName)
            {
                //do something here.
            }
    
            public void TestFinished(TestResult result)
            {
                //do something here.
            }
    
            public void TestOutput(TestOutput testOutput)
            {
                //do something here.
            }
    
            public void TestStarted(TestName testName)
            {
                //do something here.
            }
    
            public void UnhandledException(Exception exception)
            {
                //do something here.
            }
    
            #endregion
        }
    }
