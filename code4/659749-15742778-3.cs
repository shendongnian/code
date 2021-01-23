    bool doDisplayExpected =
           ShowAll()
        || ShowExpense(expected)
        || ShowNonExpense(expected);
    if (doDisplayExpected)
    {
        // code
    }
    public bool ShowAll()
    {
        return Show == Display.All;
    }
    public bool ShowExpense(Expected expected)
    {
        return Show == Display.Expense && expected.EXPENSE;
    }
    public bool ShowNonExpense(Expected expected)
    {
        return Show == Display.NonExpense && !expected.EXPENSE;
    }
