    class1 st = new class1();
    System.Threading.Thread th1 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(st.start));
    th1.Start(textBox1.Text);
---
    class class1
    {
        public void start(object o)
        {
            string m = (string)o;
            System.Diagnostics.Process.Start(m);
        }
    }
