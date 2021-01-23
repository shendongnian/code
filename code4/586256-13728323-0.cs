                var bc = comboBox1.BindingContext;
            if (bc == this.BindingContext)
            {
                if (bc.Equals(this.BindingContext))
                {
                    MessageBox.Show("combobox always use same binding context as his hosting form");
                }
            }
