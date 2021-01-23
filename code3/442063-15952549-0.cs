    /// <summary>
    /// Handles the TransactionCompleted event of the Current control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Transactions.TransactionEventArgs"/> instance containing the event data.</param>
    static void Current_TransactionCompleted(object sender, TransactionEventArgs e)
    {
        if (e.Transaction.TransactionInformation.Status == TransactionStatus.Committed)
        {
            /// Yay it's committed code goes here!
        }
    }
