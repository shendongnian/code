        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( listBox1.SelectedIndex != -1 )
            {
                var item = this.List.Item[listBox1.SelectedIndex];
                var mainControl = this.TopLevelControl as IExpressionProvider;
                if ( mainControl != null )
                    mainControl.CurrentExpression = item;
            }
        }
