    public class Summary {
        public double debits;
        public double credits;
    }
Now that you've taken care of all of the compile errors you may run the test. It will fail with a NullPointerException due to your empty implementation of the summarizeTransactionsIn method. Return a summary instance from the method and it passes.
    public Summary summarizeTransactionsIn(Scanner transactionList) {
        return new Summary();
    }
