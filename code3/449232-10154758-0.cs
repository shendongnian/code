    using System;
    using System.Data.SqlServerCe;
    using System.Data.Common;
    using System.Data;
    namespace Zoho
    {
        public partial class PotentialTableAdapter
        {
            SqlCeDataAdapter _adapter;
            SqlCeConnection _connection;
            SqlCeTransaction _transaction;
            SqlCeCommand[] _commandCollection;
            DataTable _table;
            public PotentialTableAdapter()
            {
                ClearBeforeFill = true;
                InitConnection();
                InitAdapter();
                InitCommandCollection();
                FillTable();
            }
            public bool ClearBeforeFill {get; set;}
            public SqlCeDataAdapter Adapter
            {
                get
                {
                    if ((this._adapter == null))
                    {
                        this.InitAdapter();
                    }
                    return this._adapter;
                }
            }
            public SqlCeConnection Connection
            {
                get
                {
                    if (_connection == null)
                        InitConnection();
                    return _connection;
                }
            }
            public SqlCeTransaction Transaction
            {
                get
                {
                    return _transaction;
                }
                set
                {
                    _transaction = value;
                    for (int i = 0; (i < CommandCollection.Length); i = (i + 1))
                    {
                        CommandCollection[i].Transaction = value;
                    }
                    Adapter.DeleteCommand.Transaction = value;
                    Adapter.InsertCommand.Transaction = value;
                    Adapter.UpdateCommand.Transaction = value;
                }
            }
            public SqlCeCommand[] CommandCollection
            {
                get
                {
                    if ((this._commandCollection == null))
                    {
                        InitCommandCollection();
                    }
                    return this._commandCollection;
                }
            }
            public DataTable Table
            {
                get
                {
                    if (_table == null)
                        FillTable();
                    return _table;
                }
            }
        }
    }
    using System.Data.Common;
    using System.Data.SqlServerCe;
    using System.Data;
    namespace Zoho
    {
        partial class PotentialTableAdapter
        {
                                        private void InitAdapter()
        {
            this._adapter = new SqlCeDataAdapter();
            this._adapter.TableMappings.Add(GetTableMapping());
            this._adapter.SelectCommand = new SqlCeCommand("SELECT * FROM Potential", Connection);
            this._adapter.InsertCommand = GetCommand(@"INSERT INTO [Potential] ([Soid], [SalesRep], [Account], [ClosingDate], [Amount], [Stage], [SourceId], [Product], [FirstName], [Email], [CustomerPO], [ZohoID], [WorkOrder], [ExpectedShip], [TrackingNumber], [DependencyID], [ProcessEmail], [ExpectedEmail], [ShippedEmail]) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19)");
            this._adapter.UpdateCommand = GetCommand(@"UPDATE [Potential] SET [Soid] = @p1, [SalesRep] = @p2, [Account] = @p3, [ClosingDate] = @p4, [Amount] = @p5, [Stage] = @p6, [SourceId] = @p7, [Product] = @p8, [FirstName] = @p9, [Email] = @p10, [CustomerPO] = @p11, [ZohoID] = @p12, [WorkOrder] = @p13, [ExpectedShip] = @p14, [TrackingNumber] = @p15, [DependencyID] = @p16, [ProcessEmail] = @p17, [ExpectedEmail] = @p18, [ShippedEmail] = @p19 WHERE (([NCPotentialKey] = @p20))");
        }
                        private void InitConnection()
        {
            this._connection = new SqlCeConnection(Zoho.Properties.Settings.Default.PotentialDatabaseConnectionString);
        }
                            private void InitCommandCollection()
        {
            _commandCollection = new SqlCeCommand[1];
            _commandCollection[0] = new SqlCeCommand("SELECT * FROM Potential", Connection);
        }
                            private void FillTable()
        {
            _table = new DataTable();
            Adapter.Fill(_table);
        }
                                                                                                                    private DataTableMapping GetTableMapping()
        {
            var tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "Potential";
            tableMapping.ColumnMappings.Add("Soid", "Soid");
            tableMapping.ColumnMappings.Add("SalesRep", "SalesRep");
            tableMapping.ColumnMappings.Add("Account", "Account");
            tableMapping.ColumnMappings.Add("ClosingDate", "ClosingDate");
            tableMapping.ColumnMappings.Add("Amount", "Amount");
            tableMapping.ColumnMappings.Add("Stage", "Stage");
            tableMapping.ColumnMappings.Add("SourceId", "SourceId");
            tableMapping.ColumnMappings.Add("Product", "Product");
            tableMapping.ColumnMappings.Add("FirstName", "FirstName");
            tableMapping.ColumnMappings.Add("Email", "Email");
            tableMapping.ColumnMappings.Add("CustomerPO", "CustomerPO");
            tableMapping.ColumnMappings.Add("ZohoID", "ZohoID");
            tableMapping.ColumnMappings.Add("WorkOrder", "WorkOrder");
            tableMapping.ColumnMappings.Add("ExpectedShip", "ExpectedShip");
            tableMapping.ColumnMappings.Add("TrackingNumber", "TrackingNumber");
            tableMapping.ColumnMappings.Add("DependencyID", "DependencyID");
            tableMapping.ColumnMappings.Add("ProcessEmail", "ProcessEmail");
            tableMapping.ColumnMappings.Add("ExpectedEmail", "ExpectedEmail");
            tableMapping.ColumnMappings.Add("ShippedEmail", "ShippedEmail");
            tableMapping.ColumnMappings.Add("NCPotentialKey", "NCPotentialKey1");
            return tableMapping;
        }
                                                private SqlCeCommand GetDeleteCommand()
        {
            var deleteCommand = new SqlCeCommand();
            deleteCommand.Connection = this.Connection;
            deleteCommand.CommandText = "DELETE FROM [Potential] WHERE (([NCPotentialKey] = @p1))";
            deleteCommand.CommandType = CommandType.Text;
            var parameter = new SqlCeParameter("@p1", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "NCPotentialKey", DataRowVersion.Original, null);
            deleteCommand.Parameters.Add(parameter);
            return deleteCommand;
        }
            private SqlCeCommand GetCommand(string text)
            {
                var command = new SqlCeCommand(text);
                command.Connection = this.Connection;
                command.Parameters.Add(new SqlCeParameter("@p1", SqlDbType.Int, 0,      ParameterDirection.Input, true, 0, 0, "Soid",          DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p2", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "SalesRep",      DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p3", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "Account",       DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p4", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "ClosingDate",   DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p5", SqlDbType.Money, 0,    ParameterDirection.Input, true, 0, 0, "Amount",        DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p6", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "Stage",         DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p7", SqlDbType.Int, 0,      ParameterDirection.Input, true, 0, 0, "SourceId",      DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p8", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "Product",       DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p9", SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "FirstName",     DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p10",SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "Email",         DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p11",SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "CustomerPO",    DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p12",SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "ZohoID",        DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p13",SqlDbType.Int, 0,      ParameterDirection.Input, true, 0, 0, "WorkOrder",     DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p14",SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "ExpectedShip",  DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p15",SqlDbType.NVarChar, 0, ParameterDirection.Input, true, 0, 0, "TrackingNumber",DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p16",SqlDbType.Int, 0,      ParameterDirection.Input, true, 0, 0, "DependencyID",  DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p17",SqlDbType.Bit, 0,      ParameterDirection.Input, true, 0, 0, "ProcessEmail",  DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p18",SqlDbType.Bit, 0,      ParameterDirection.Input, true, 0, 0, "ExpectedEmail", DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p19",SqlDbType.Bit, 0,      ParameterDirection.Input, true, 0, 0, "ShippedEmail",  DataRowVersion.Current, null));
                command.Parameters.Add(new SqlCeParameter("@p20",SqlDbType.Int, 0,      ParameterDirection.Input, true, 0, 0, "NCPotentialKey",DataRowVersion.Original, null));
                return command;
            }
        }
    }
