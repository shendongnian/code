    catch (Exception ex)
    {
        if (ex.InnerException != null)
        {
            lblMessage.Text = "Error : " + ex.InnerException.Message;
        }
        else
        {
            lblMessage.Text = "Error : " + ex.Message;
        }
    }
