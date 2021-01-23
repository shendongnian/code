        Process calc;
        
        private void button1_Click(object sender, EventArgs e) {
            if (calc != null) return;
            calc = new Process();
            calc.StartInfo = new ProcessStartInfo("calc.exe");
            calc.EnableRaisingEvents = true;
            calc.Exited += new EventHandler(calc_Exited);
            calc.SynchronizingObject = this;
            calc.Start();
            button1.Enabled = false;
        }
        void calc_Exited(object sender, EventArgs e) {
            calc.Exited -= calc_Exited;
            calc = null;
            button1.Enabled = true;
        }
