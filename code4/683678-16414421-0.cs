    public void DeleteStrategyFuture()
    {
        var length=futureContainer.Controls.Count;
        foreach(int i=0; i< length; i++)
        {
            if(futureContainer.Controls[i].GetType()==typeof(ConsoleStrategyItem))
            { 
               bool isChecked =((ConsoleStrategyItem)futureContainer.Controls[i])
                                   .Instance.cbxDeleteStrategy.Checked;
               if(isChecked)
               {
                   futureContainers.Controls.Remove(futureContainers.Controls[i]);
               }
            }
         }
    }
