    private void timer1_Tick(object sender, EventArgs e)
        {
            r3.Select();
            System.Threading.Thread.Sleep(x);
            if(timer1.Enabled == false) return;
                r2.Select();
                System.Threading.Thread.Sleep(x);
                if(timer1.Enabled == false) return;
                r1.Select();
                System.Threading.Thread.Sleep(x);
                if(timer1.Enabled == false) return;
                r2.Select();
                System.Threading.Thread.Sleep(x);
                if(timer1.Enabled == false) return;
                r3.Select();
                System.Threading.Thread.Sleep(x);
                if(timer1.Enabled == false) return;
                r4.Select();
                System.Threading.Thread.Sleep(x);
                }
