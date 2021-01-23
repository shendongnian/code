private object once = new object();
public void setOutput(int value)
    {
        lock (once)
        {
            try
            {
                GPOs gpos = reader.Config.GPO;
                gpos[1].PortState = GPOs.GPO_PORT_STATE.TRUE;
                gpos[2].PortState = GPOs.GPO_PORT_STATE.TRUE;
                Thread.Sleep(WAIT);
                gpos[1].PortState = GPOs.GPO_PORT_STATE.FALSE;
                gpos[2].PortState = GPOs.GPO_PORT_STATE.FALSE;
            }
            catch (Exception ex)
            {
                logger.Error("An Exception occure while setting GPO to " + value + " " + ex.Message);
            }
        }
    }
