    .Lambda #Lambda1<System.Func`2[ConsoleApplication7.Customer,System.Boolean]>(ConsoleApplication7.Customer $c) {
    .Call System.Linq.Enumerable.Any(
        (.Constant<ConsoleApplication7.Program+<>c__DisplayClass0>(ConsoleApplication7.Program+<>c__DisplayClass0).ctx).Invoice,
        .Lambda #Lambda2<System.Func`2[ConsoleApplication7.Customer,System.Boolean]>)
    }
    
    .Lambda #Lambda2<System.Func`2[ConsoleApplication7.Customer,System.Boolean]>(ConsoleApplication7.Customer $i) {
        $i.customerId == $c.id
    }
