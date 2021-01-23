    using Siderite.Tests;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Xunit;
    using Xunit.Abstractions;
    using Xunit.Sdk;
    
    [assembly: TestFramework(
        SideriteTestFramework.TypeName,
        SideriteTestFramework.AssemblyName)]
    
    namespace Siderite.Tests
    {
        public class SideriteTestFramework : ITestFramework
        {
            public const string TypeName = "Siderite.Tests.SideriteTestFramework";
            public const string AssemblyName = "Siderite.Tests";
            private readonly XunitTestFramework _innerFramework;
    
            public SideriteTestFramework(IMessageSink messageSink)
            {
                _innerFramework = new XunitTestFramework(messageSink);
            }
    
            public ISourceInformationProvider SourceInformationProvider
            {
                set
                {
                    _innerFramework.SourceInformationProvider = value;
                }
            }
    
            public void Dispose()
            {
                _innerFramework.Dispose();
            }
    
            public ITestFrameworkDiscoverer GetDiscoverer(IAssemblyInfo assembly)
            {
                return _innerFramework.GetDiscoverer(assembly);
            }
    
            public ITestFrameworkExecutor GetExecutor(AssemblyName assemblyName)
            {
                var executor = _innerFramework.GetExecutor(assemblyName);
                return new SideriteTestExecutor(executor);
            }
    
            private class SideriteTestExecutor : ITestFrameworkExecutor
            {
                private readonly ITestFrameworkExecutor _executor;
                private IEnumerable<ITestCase> _testCases;
    
                public SideriteTestExecutor(ITestFrameworkExecutor executor)
                {
                    this._executor = executor;
                }
    
                public ITestCase Deserialize(string value)
                {
                    return _executor.Deserialize(value);
                }
    
                public void Dispose()
                {
                    _executor.Dispose();
                }
    
                public void RunAll(IMessageSink executionMessageSink, ITestFrameworkDiscoveryOptions discoveryOptions, ITestFrameworkExecutionOptions executionOptions)
                {
                    _executor.RunAll(executionMessageSink, discoveryOptions, executionOptions);
                }
    
                public void RunTests(IEnumerable<ITestCase> testCases, IMessageSink executionMessageSink, ITestFrameworkExecutionOptions executionOptions)
                {
                    _testCases = testCases;
                    _executor.RunTests(testCases, new SpySink(executionMessageSink, this), executionOptions);
                }
    
                internal void Finished(TestAssemblyFinished executionFinished)
                {
                    // do something with the run test cases in _testcases and the number of failed and skipped tests in executionFinished
                }
            }
    
    
            private class SpySink : IMessageSink
            {
                private readonly IMessageSink _executionMessageSink;
                private readonly SideriteTestExecutor _testExecutor;
    
                public SpySink(IMessageSink executionMessageSink, SideriteTestExecutor testExecutor)
                {
                    this._executionMessageSink = executionMessageSink;
                    _testExecutor = testExecutor;
                }
    
                public bool OnMessage(IMessageSinkMessage message)
                {
                    var result = _executionMessageSink.OnMessage(message);
                    if (message is TestAssemblyFinished executionFinished)
                    {
                        _testExecutor.Finished(executionFinished);
                    }
                    return result;
                }
            }
        }
    }
