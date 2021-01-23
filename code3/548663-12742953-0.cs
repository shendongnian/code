    public static int GetConveyorProductionCount(string machineNameV, DateTime StartTimeV, DateTime EndTimeV)
        {
        enter code here
            try
            {
                int count;
    
                SqlParameter param01 = new SqlParameter("@param01", SqlDbType.VarChar, 5);
                param01.Value = machineNameV;
    
                SqlParameter param02 = new SqlParameter("@param02", SqlDbType.date);
                param02.Value = StartTimeV;
    
                SqlParameter param03 = new SqlParameter("@param03", SqlDbType.date);
                param03.Value = EndTimeV;
    
                SqlCommand getConveyorProductionSC = new SqlCommand("SELECT cast([" + machineNameV + "] as int) FROM VWCONVEYORPRODUCTION WHERE([DA_TE] BETWEEN @param02 AND @param03)", myConnection);
    
                getConveyorProductionSC.Parameters.Add(param01);
                getConveyorProductionSC.Parameters.Add(param02);
                getConveyorProductionSC.Parameters.Add(param03);
    
                myConnection.Open();
                object result = getConveyorProductionSC.ExecuteScalar();
                myConnection.Close();
    
                if (result == DBNull.Value)
                {
                    count = 0;
                }
                else
                {
                    count = Convert.ToInt32(result);
                }
    
                return count;
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving the Conveyor production count. Error: " + e.Message);
            }
