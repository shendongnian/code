    public int CreateMyTask()
    {
        int value = -1;
        try
        {
            Console.WriteLine("Invoking CreateTask method");
            Console.WriteLine("-----------------------------------");
            m_taskID = taskClient.CreateTask(m_tInstance);
            Console.WriteLine("Task create successfully:ID=" + m_taskID.ToString());
            Console.WriteLine("-----------------------------------");
            value = m_taskID;
        }
        catch (Exception ex)
        {
            MessageBox.Show("An exception has occured. Please check the Excel sheet for more info" + ex);
        }
        finally
        {
            GC.Collect();
        }
        
        return value;
    }
