    public partial class ServerSetupDTO
    {
        public DataSet ToDataSet()
        {
            
            var setupDataSet = new DataSet("ServerSetup");
            //Get the demos
            var demoPreconfigsTable = setupDataSet.Tables.Add("DemoPreconfigs");
            demoPreconfigsTable.Columns.Add("AllowedServer");
            demoPreconfigsTable.Columns.Add("SqlInstance");
            demoPreconfigsTable.Columns.Add("DatabaseName");
            this.DemoPreconfigs.ForEach(item => demoPreconfigsTable.Rows.Add(item.AllowedServer, item.SqlInstance, item.DatabaseName));
            //Get the preconfigs
            var genericPreconfigsTable = setupDataSet.Tables.Add("GenericPreconfigs");
            genericPreconfigsTable.Columns.Add("AllowedServer");
            genericPreconfigsTable.Columns.Add("SqlInstance");
            genericPreconfigsTable.Columns.Add("DatabaseName");
            this.GenericPreconfigs.ForEach(item => genericPreconfigsTable.Rows.Add(item.AllowedServer, item.SqlInstance, item.DatabaseName));
            //Get the servers
            var sqlServersTable = setupDataSet.Tables.Add("SqlServers");
            sqlServersTable.Columns.Add("ServerName");
            this.SqlServers.ForEach(item => sqlServersTable.Rows.Add(item));
            //Get the VM's
            var virtualMachinesTable = setupDataSet.Tables.Add("VirtualMachines");
            virtualMachinesTable.Columns.Add("MachineName");
            this.VirtualMachines.ForEach(item => virtualMachinesTable.Rows.Add(item));
            return setupDataSet;
        }
    }
