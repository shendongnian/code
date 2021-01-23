        protected override void OnDropDownClosed(EventArgs e)
        {
            Console.WriteLine("OnDropDownClosed " +
                 this.SelectedIndex + " " + this.Text);
            int idx = this.SelectedIndex;
            base.OnDropDownClosed(e);
            this.SelectedIndex = idx;
        }
