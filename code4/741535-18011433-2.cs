    using (var testCase = new MyFirstTestCase)
    {
       DoThis();
       DoThat();
    } // Automatic garbage collect of testCase object
