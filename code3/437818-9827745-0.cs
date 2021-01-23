    public void ShowResults()
    {
      while (true)
      {
        Thread.Sleep(1000); // don't spam the UI thread
    
        if (this.InvokeRequired) 
        {
          this.Invoke((Action)UpdateGui);
        }  
        else
        {
          UpdateGui();
        }
      } 
    }
    
    private void UpdateGui() 
    {  
      loopsNum.Text = Convert.ToString(resultLoopsNum);
      nodesVisitedNum.Text = Convert.ToString(resultNodesVisitedNum);
      nodesResolvedNum.Text = Convert.ToString(resultNodesResolvedNum);
      cpuLoopsNum.Text = Convert.ToString(resultCpuLoopsNum);
      shortestPathCostNum.Text = Convert.ToString(resultShortestPathCost);
    }
