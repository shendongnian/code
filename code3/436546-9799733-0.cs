    private void button1_Click(object sender, EventArgs e)
            {
                Delay delay = new Delay();
                int delayResult = 0;
                Thread t = new Thread(delegate() { delayResult = delay.Convert(); });
                t.Start();
                while (t.IsAlive)
                {
                    System.Threading.Thread.Sleep(500);
                }
                MessageBox.Show(delayResult.ToString()); 
            }
