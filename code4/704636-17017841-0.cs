        void radPageView1_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            e.Page.Item.BackColor = Color.Red;
            e.Page.Item.DrawFill = true;
            e.Page.Item.GradientStyle = GradientStyles.Solid;
            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
        }
