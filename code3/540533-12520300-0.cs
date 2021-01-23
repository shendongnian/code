        textBox1.MouseMove += new MouseEventHandler(controls_MouseMove);
        textBox2.MouseMove += new MouseEventHandler(controls_MouseMove);
        ...
        void controls_MouseMove(object sender, MouseEventArgs e)
        {
            Control subc=sender as Control;
            int mouseX = MousePosition.X;
            ....
        }
