    catch (Exception e)
    {
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            ErrorStatus.Text = e.ToString();
        }
    }
 
