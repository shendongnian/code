    class Form2
    {
        private IAddValues _valueAdder;
        public Form2()
        {
            // ...
        }
        public Form2(IAddValues valueAdder):this()
        {
            _valueAdder = valueAdder;
        }
        void Button_Click(object sender, EventArgs e)
        {
            if(_valueAdder != null)
            {
                _valueAdder.AddValue(textBox1.Text);
            }
        }
    }
