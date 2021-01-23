     private void button1_Click(object sender, EventArgs e)
        {
            MethodInfo val = this.GetType().GetMethod("Foo");
            val.Invoke(this, new object[] {"1", "2"});
        }
        public void Foo(string p1, string p2)
        {
            MessageBox.Show("");
        }
