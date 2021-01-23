    public int CreateMyTask()
    {
        int returnValue = -1;       
        try
        {
            Console.WriteLine("Invoking CreateTask method");
            Console.WriteLine("-----------------------------------");
            m_taskID = taskClient.CreateTask(m_tInstance);
            Console.WriteLine("Task create successfully:ID=" + m_taskID.ToString());
            Console.WriteLine("-----------------------------------");
            returnValue = m_taskID;
        }
        catch (Exception ex)
        {
            MessageBox.Show("An exception has occured. Please check the Excel sheet for more info" + ex);
            returnValue = -1;  // Shouldn't be necessary but the compiler likes it
        }
        finally
        {
            GC.Collect();
        }
        
        return returnValue;
    }
