    btnOnForm1OnUIThread1_Click(...)
    {
        UpdateForm2OnUIThread2();
    }
    UpdateForm2OnUIThread2()
    {
        if (control.InvokeRequired)
        {
          // Syntax of this line may be slightly off as I'm writing from memory ... 
          // I normally use an extension method
          control.Invoke(UpdateForm2OnUIThread2); 
        }
        else
        {
          control.Text = "Blah";
        }    
    }
