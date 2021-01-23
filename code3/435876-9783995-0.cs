    try
    {
      WaitForm.Display();
      // Some code
    }
    finally
    {
      WaitForm.Hide();
      Application.DoEvents();
    }
