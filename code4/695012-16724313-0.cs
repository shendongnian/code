        void ValueChanged(object sender, EventArgs e)
        {
        BoundData_PropertyChanged();
        }
       textBox.TextChanged += new System.EventHandler(ValueChanged);
