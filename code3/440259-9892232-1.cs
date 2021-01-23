    .Lambda #Lambda1<System.Func`2[ConsoleApplication7.TestObject,System.Boolean]>(ConsoleApplication7.TestObject $t) {
        .Call System.Linq.Enumerable.Any(
            $t.Invoice,
            .Lambda #Lambda2<System.Func`2[ConsoleApplication7.Customer,System.Boolean]>)
    }
    
    .Lambda #Lambda2<System.Func`2[ConsoleApplication7.Customer,System.Boolean]>(ConsoleApplication7.Customer $i) {
        $i.CustomerId == $t.Id
    }
