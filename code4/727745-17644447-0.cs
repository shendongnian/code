    decimal TruncateTo100ths(decimal d)
    {
        return Math.Truncate(d* 100) / 100;
    }
    TruncateTo100ths(0m);       // 0
    TruncateTo100ths(2.919m);   // 2.91
    TruncateTo100ths(2.91111m); // 2.91
    TruncateTo100ths(2.1345m);  // 2.13
