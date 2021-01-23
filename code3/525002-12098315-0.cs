        private void button1_Click(object sender, EventArgs e)
        {
            Button(new Action(Print));
            Button();
        }
        public void Button(Action command = null)
        {
            if (command == null)
            {
                command = DefaultMethod;
            }
            command.Invoke();
        }
        private void DefaultMethod()
        {
            MessageBox.Show("default");
        }
        private void Print()
        {
            MessageBox.Show("printed");
        }
