        public override void PaymentQueueRestoreCompletedTransactionsFinished (SKPaymentQueue queue)
			{
				foreach(SKPaymentTransaction transaction in queue.Transactions)
				{
					#if DEBUG
					Console.WriteLine("Restoring Transaction " + transaction.Payment.ProductIdentifier);
					#endif
					theManager.restoreTransaction(transaction);
				}
			}
