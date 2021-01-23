    delegate void TestDelegate(object o);
    
            private void button4_Click(object sender, EventArgs e)
            {
                TestDelegate custom = SomeMethod;
                ParameterizedThreadStart pts = new ParameterizedThreadStart(custom);
                Thread thread = new Thread(pts);
                thread.Start();
            }
    
            private void SomeMethod(object o)
            {
                MessageBox.Show("Hey!");
            }
