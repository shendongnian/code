        internal class A
        {
            internal int X = 5;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            A a = new A();
            MessageBox.Show(a.X.ToString());
        }
