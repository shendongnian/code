    @Test
    public void summarizesDebit() {
        TransactionSummarization summarizer = new TransactionSummarization();
        Summary s = summarizer.summarizeTransactionsIn(new Scanner("01/01/12,DB,1.00"));
        assertEquals(1.00, s.debits, 0.0);
        assertEquals(0.00, s.credits, 0.0);
    }
After running the test, we should see it fail because we aren't accumulating the values, simply returning a new Summary
    public Summary summarizeTransactionsIn(Scanner transactionList) {
        String currentLine = transactionList.nextLine();
        txAmount = currentLine.split(",")[2];
        double amount = Double.parseDouble(txAmount);
        return new Summary(amount);
    }
After fixing the compile error in Summary and implementing the constructor your tests should be passing again. What's the next test? What can we learn? Well, I'm curious about that debit/credit thing, so let's do that next.
    @Test
    public void summarizesCredit() {
        TransactionSummarization summarizer = new TransactionSummarization();
        Summary s = summarizer.summarizeTransactionsIn(new Scanner("01/01/12,CR,1.00"));
        assertEquals(0.00, s.debits, 0.0);
        assertEquals(1.00, s.credits, 0.0);
    }
