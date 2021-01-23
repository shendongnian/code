    catch (Exception ex)
    {
        if (ex.Data.Contains("UserMessage"))
        {
            MessageBox.Show(ex.Data["UserMessage"].ToString());
        }
        else
        {
            MessageBox.Show(ex.Message);
        }
    }
