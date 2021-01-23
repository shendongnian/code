    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                while (true)
                {
                    if ((worker.CancellationPending == true))
                    {
                        e.Cancel = true;
    
                        break;
                    }
                    else
                    {
                        if (tempCpuValue >= (float?)numericUpDown1.Value || tempGpuValue >= (float?)numericUpDown1.Value)
                        {
                            soundPlay = true;
                            blinking_label();
                        }
                        else
                        {
                            soundPlay = false;
                        }
                        cpuView();
                        gpuView();
                        Thread.Sleep(1000);
                    }
                }
    
                  _resetEvent.Set(); // signal that worker is done
            }
