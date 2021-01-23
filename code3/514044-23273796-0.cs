    public static void SetAsDefaultView(this SPList self, string viewName)
        {
            if (!self.Views[viewName].DefaultView)
            {
                self.DefaultView.DefaultView = false;
                self.Views[viewName].DefaultView = true;
                self.Update();
            }
        }
