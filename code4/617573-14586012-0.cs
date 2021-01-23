        public void Main()
        {
            bool debug = Convert.ToBoolean(Dts.Variables["Debug"].Value);
            string taskName = string.Empty;
            string packageName = string.Empty;
            string sourceName = string.Empty;
            bool fireAgain = false;
            taskName = Convert.ToString(Dts.Variables["TaskName"].Value);
            packageName = Convert.ToString(Dts.Variables["PackageName"].Value);
            // Fix this by defining and passing in params
            sourceName = Convert.ToString(Dts.Variables["TaskName"].Value);
            System.Data.OleDb.OleDbDataAdapter adapater = null;
            System.Data.DataTable table = null;
            System.Data.DataColumn column = null;
            System.Data.DataRow row = null;
            string message = string.Empty;
            object rowCounts = null;
            rowCounts = Dts.Variables["RowCounts"].Value;
            table = new DataTable();
            try
            {
                // Get us out of this crazy thing - should only be an issue
                // first pass through
                if (rowCounts == null)
                {
                    Dts.TaskResult = (int)ScriptResults.Success;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed here");
            }
            adapater = new System.Data.OleDb.OleDbDataAdapter();
            try
            {
                // This works if we pass in a dataset
                //adapater.Fill(table, Dts.Variables["RowCounts"].Value);
                adapater.Fill(table, rowCounts);
                // TODO: Enumerate through adapter
                // Call Output0Buffer.AddRow();
                // and Output0Buffer.MyColumn.Value = adapter[i].value // possibly casting to strong type
            }
            catch (Exception ex)
            {
                try
                {
                    // This works if we use a datatable
                    System.Data.DataSet ds = null;
                    //ds = (DataSet)Dts.Variables["RowCounts"].Value;
                    ds = (DataSet)rowCounts;
                    table = ds.Tables[0];
                    // TODO: Enumerate through datatable as we do with adapter
                }
                catch (Exception innerException)
                {
                    // continue to swallow exceptions
                }
                Dts.Variables["ValidCounts"].Value = false;
                // trap "Object is not an ADODB.RecordSet or an ADODB.Record
                // parse ex.Message
                if (ex.Message.Contains("System.ArgumentException: "))
                {
                    System.Text.StringBuilder exceptionMessage = null;
                    exceptionMessage = new System.Text.StringBuilder();
                    exceptionMessage.Append(ex.Message);
                    exceptionMessage.Replace("\nParameter name: adodb", string.Empty);
                    exceptionMessage.Replace("System.ArgumentException: ", string.Empty);
                    if (exceptionMessage.ToString() != "Object is not an ADODB.RecordSet")
                    {
                        Dts.Events.FireInformation(0, string.Format("{0}.{1}", packageName, taskName), exceptionMessage.ToString(), string.Empty, 0, ref fireAgain);
                    }
                }
            }
            Dts.Variables["ValidCounts"].Value = false;
            if (table.Rows.Count > 0)
            {
                Dts.Variables["ValidCounts"].Value = true;
            }
            if (debug)
            {
                message = string.Format("SourceName:  {0}\nValidCounts:  {1}", sourceName, false);
                //System.Windows.Forms.MessageBox msgBox = null;
                //msgBox = new MessageBox();
                System.Windows.Forms.MessageBox.Show(message, string.Format("{0}.{1}", packageName, taskName));
                //MessageBox(message, string.Format("{0}.{1}", packageName, taskName));
            }
            Dts.TaskResult = (int)ScriptResults.Success;
        }
