    private bool resize_flag = true;
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!resize_flag) return;
            //your code here
            resize_flag = true;
        }
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            resize_flag = false;
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //your code here
            resize_flag = true;
        }
