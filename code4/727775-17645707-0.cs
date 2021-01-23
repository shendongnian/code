    TaskForm.Show(this, "Task is executing...", "Step 1 - Preparing...", 
                        "Runninig", true, ProgressBarStyle.Continuous);
    for (int i = 1; i <= 100; i++)
    {
      TaskForm.UpdateInstructionText("Step 1 - Executing..." + i );
      TaskForm.UpdateStatus("Running " + i);
      TaskForm.UpdateProgress(i);
    
      Thread.Sleep(1000);
    }
