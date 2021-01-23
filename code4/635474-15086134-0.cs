        private void Form1_Load(object sender, EventArgs e)
        {
            this.Resize += OnResize;
        }
        private void OnResize(object sender, EventArgs eventArgs)
        {
            if (form2running && form != null && (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal))
            {
                form.Invoke((MethodInvoker)(() => form.WindowState = FormWindowState.Normal));
            }
        }
        private bool form2running = false;
        private Form form;
        private void button2_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(ShowNewForm);
        }
        private void ShowNewForm(object o)
        {
            form2running = true;
            form = new Form2();
            Application.Run(form);
            form2running = false;
        }
