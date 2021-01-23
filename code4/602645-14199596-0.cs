    private bool autoFinish = true;
    
    public void SuspendAutoFinish() { this.autoFinish = false; }
    public void ResumeAutoFinish() { this.autoFinish = true; FinishDisplay(); }
    
    private void UpdateOrderView() {
      // ...
      if(this.autoFinish) FinishDisplay();
    }
    
    // consumer
    try {
      myImpl.SuspendAutoFinish();
      myImpl.MoveItems(myCollection);
    }
    finally {
      myImpl.ResumeAutoFinish();
    }
