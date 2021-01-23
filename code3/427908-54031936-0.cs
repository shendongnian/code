    Imports System.Data.SqlClient
    Imports Microsoft.SqlServer.Management.Common
    Imports Microsoft.SqlServer.Management.Smo
    Imports Microsoft.SqlServer.Management.Smo.Agent
    public void RunSQLAgentJob(string JobName)
	{
	    SqlConnection DbConn = new SqlConnection(connectionstring);
	    ServerConnection conn;
	    Job job;
	    Server server;
	
	    using (DbConn) {
	        conn = new ServerConnection(DbConn);
	        server = new Server(conn);
	        job = server.JobServer.Jobs(JobName);
            // make sure it's not already running before starting it
            if (job.CurrentRunStatus == JobExecutionStatus.Idle) 
                job.Start();
            while (job.CurrentRunStatus == JobExecutionStatus.Executing) {
                job.Refresh();
                Console.WriteLine($"Current status of {JobName} is {job.CurrentRunStatus.ToString}");
                System.Threading.Thread.Sleep(3000);
            }
	    }
	}
