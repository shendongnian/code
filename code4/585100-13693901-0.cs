    multicast my_multicast = null;
    if (line_split[i].Contains("LabelId"))
    {
       try
       {
           gen.m_LabelId_pos.Add(multicast_ports[3], i);
           my_multicast = new multicast();
       }
       catch
       {
       }
    }
    else if (line_split[i].Contains("TotalFrameSentCount_PerSecond"))
    {
        try
        {                                    
            gen.m_TotalFrameSentCount_PerSecond_pos.Add(multicast_ports[3], i);
            if(my_multicast!=null)
            {
                //do something with my_multicast here
            }
        }
        catch
        {
        }
    }
