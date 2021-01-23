        18:57:46.665  03064/05180 <{{         > ApiChange.IntegrationTests.Diagnostics.TracingTests.SomeMethod  
        18:57:46.668  03064/05180 <{{         > ApiChange.IntegrationTests.Diagnostics.TracingTests.SomeOtherMethod  
        18:57:46.670  03064/05180 <         }}< ApiChange.IntegrationTests.Diagnostics.TracingTests.SomeOtherMethod Exception thrown: System.NotImplementedException: Hi this a fault    
    at ApiChange.IntegrationTests.Diagnostics.TracingTests.FaultyMethod()  
    at ApiChange.IntegrationTests.Diagnostics.TracingTests.SomeOtherMethod()  
    at ApiChange.IntegrationTests.Diagnostics.TracingTests.SomeMethod()    
    at ApiChange.IntegrationTests.Diagnostics.TracingTests.Demo_Show_Leaving_Trace_With_Exception() 
        
    18:57:46.670  03064/05180 <         }}< ApiChange.IntegrationTests.Diagnostics.TracingTests.SomeOtherMethod Duration 2ms 18:57:46.689  03064/05180 <         }}< ApiChange.IntegrationTests.Diagnostics.TracingTests.SomeMethod Duration 24ms
