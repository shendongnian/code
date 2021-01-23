    PerformanceTester tester;
    using (tester = new PerformanceTester())    
        SomeAction();
    MessageBox.Show(tester.Results.ToString());
        
    
