    class Form2 {
        public string Value { get; set; }
        public Form2(string value) {
            Value = value;
        }
        
        public void Form2_Load() {
            textBox1.Text = Value;
        }
    }
