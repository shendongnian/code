    using System.IO;
    using System.Text;
    using System.Transactions;
    
    namespace Sakher.Transactions
    {
        public class TsansactionalFileWriter
        {
            private FileTransactionEnlistment fileTransactionEnlistment = new FileTransactionEnlistment();
            public TsansactionalFileWriter(string filePath)
            {
                fileTransactionEnlistment.FilePath = filePath;
                Transaction.Current.EnlistVolatile(fileTransactionEnlistment, EnlistmentOptions.None);
            }
    
            public void AppendText(string text)
            {
                fileTransactionEnlistment.Content.Append(text);
            }
    
            public void WriteAllText(string text)
            {
                fileTransactionEnlistment.Content = new StringBuilder(text);
            }
        }
    
        public class FileTransactionEnlistment : IEnlistmentNotification
        {
            public string FilePath { get; set; }
            public StringBuilder Content { get; set; }
            
            public FileTransactionEnlistment()
            {
                Content = new StringBuilder();
            }
    
            public void Commit(Enlistment enlistment)
            {
                File.WriteAllText(FilePath, Content.ToString());
            }
    
            public void InDoubt(Enlistment enlistment)
            {
    
            }
    
            public void Prepare(PreparingEnlistment preparingEnlistment)
            {
                //You can create the file here
                preparingEnlistment.Prepared();
            }
    
            public void Rollback(Enlistment enlistment)
            {
                //Do ssomething when the transaction is rolled-back (You may delete the file if you have created it!)
            }
        }
    
    }
