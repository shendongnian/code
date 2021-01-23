    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using Microsoft.Synchronization;
    using Microsoft.Synchronization.Data;
    using Microsoft.Synchronization.Data.SqlServer;
    using Microsoft.Synchronization.Data.SqlServerCe;
    
    namespace ExecuteExpressSync
    {
        class Program
        {
            static void Main(string[] args)
            {
                SqlConnection clientConn = new SqlConnection(@"Data Source=.\SQLCLIENT; Initial Catalog=SyncExpressDB; Trusted_Connection=Yes");
    
                SqlConnection serverConn = new SqlConnection("Data Source=localhost\\SQLEXPRESS; Initial Catalog=SyncDB; Integrated Security=True");
    
                // create the sync orhcestrator
                SyncOrchestrator syncOrchestrator = new SyncOrchestrator();
    
                // set local provider of orchestrator to a sync provider associated with the 
                // ProductsScope in the SyncExpressDB express client database
                syncOrchestrator.LocalProvider = new SqlSyncProvider("ProductsScope", clientConn);
    
    
                // set the remote provider of orchestrator to a server sync provider associated with
                // the ProductsScope in the SyncDB server database
                syncOrchestrator.RemoteProvider = new SqlSyncProvider("ProductsScope", serverConn);
    
    
                // set the direction of sync session to Upload and Download
                syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;
    
    
                // subscribe for errors that occur when applying changes to the client
                ((SqlSyncProvider)syncOrchestrator.RemoteProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);
                ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);
    
                // 
                makeConflict(clientConn, "999");
                makeConflict(serverConn, "666");
    
                // execute the synchronization process
                SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();
    
                // print statistics
                Console.WriteLine("Start Time: " + syncStats.SyncStartTime);
                Console.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
                Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
                Console.WriteLine("Download failed: " + syncStats.DownloadChangesFailed);
                Console.WriteLine("Upload Changes failed: " + syncStats.UploadChangesFailed);
                Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
                Console.WriteLine(String.Empty);
    
                Console.ReadLine();
    
            }
    
            static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
            {
                // display conflict type
                Console.WriteLine(e.Conflict.Type);
    
                // display error message 
                Console.WriteLine(e.Error);
            }
    
            private static void makeConflict(SqlConnection nodeConn, String price)
            {
                int rowCount = 0;
    
                using (nodeConn)
                {
                    SqlCommand sqlCommand = nodeConn.CreateCommand();
    
                    sqlCommand.CommandText = "UPDATE Products SET ListPrice = " + price + " WHERE Name = 'PCClient' ";
    
    
                    nodeConn.Open();
                    rowCount = sqlCommand.ExecuteNonQuery();
                    nodeConn.Close();
    
                }
            }
    
        }
    }
