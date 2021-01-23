    public class TransactionSummarizationTest {
        @Test
        public void summarizesAnEmptyDocument() {
            TransactionSummarization summarizer = new TransactionSummarization();
            Summary s = summarizer.summarizeTransactionsIn(new Scanner());
            assertEquals(0.00, s.debits, 0.0);
            assertEquals(0.00, s.credits, 0.0);
        }
Since the TransactionSummarization and Summary classes don't exist yet, you create them now. They would look like so:
