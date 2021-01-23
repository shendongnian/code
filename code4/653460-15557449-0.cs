    void Stop()
    {
        if (objectListView1.InvokeRequired)
        {
             objectListView1.BeginInvoke(new Action(Stop));
             return;
        }
        foreach (EquipmentObj obj in this.objectListView1.Objects)
        {
            obj.Stop();
        }
    }
   
