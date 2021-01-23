        public void LabelWrite(string value)
        {
            if (InvokeRequired)
                Invoke(new LabelWriteDelegate(LabelWrite), value);
            else
            {
                textBox1.Text = value;
            }
        }
        delegate void LabelWriteDelegate(string value);
