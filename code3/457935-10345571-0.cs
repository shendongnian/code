    private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VisualStateManager.GoToState(btnLogin, "Pressed", true);
                this.Refresh();
                System.Threading.Thread.Sleep(300);
                VisualStateManager.GoToState(btnLogin, "Normal", true);
                this.Refresh();
                btnLogin_Click(sender, e);
            }
        }
'
