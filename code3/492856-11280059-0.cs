        internal class A
        {
            internal int X = 5;
        }
        static class B
        {
            public static void Show()
            {
                A a = new A();
                MessageBox.Show(a.X.ToString());
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            B.Show();
        }
