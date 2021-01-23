    private void mymethod()
    {
        int a = 10;
        int b = 0;
        try
        {
            int c = a / b;
        }
        catch (Exception ex)//Second catch
        {
            MessageBox.Show(ex.ToString());
            //int c = a / b;
            throw; // change here
        }
    }
