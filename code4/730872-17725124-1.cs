     public class MyButton : Button
    {
        private bool isClickEventAttached = false;
        protected override void OnClick()
        {
            if (!isClickEventAttached)
            {
                this.Click += MyButton_Click;
                isClickEventAttached = true;
            }
            //dont forget to do this base.Click() otherwise your 
            //button click event that you will subscribe in your application will not fire
            base.OnClick();
        }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            var button=sender as Button;
            if (button != null)
                App.ButtonNames.Add((button.Name));
        }
    }
