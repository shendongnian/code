     private void timer1_Tick(object sender, EventArgs e)
        {
            string[] DF_Engines = { Form2.Engine1, Form2.Engine2, Form2.Engine3, Form2.Engine4, Form2.Engine5, Form2.Engine6 };
            sampleBackgroundWorker.RunWorkerAsync(DF_Engines);
        }
    private void sampleBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        string[] DF_Engines = (e.Argument as string[]);
        foreach (string DF_Engine in DF_Engines)
        {
            if (Convert.ToDouble(DF_Engine) != 99)
            {
                string Hex_ADD1 = "{" + DF_Engine + "|";
                Console.WriteLine(Hex_ADD1);
                serialPort1.Write(Hex_ADD1);
                //n gets overwritten in each iteration, is this line required?
                n = Convert.ToInt16(DF_Engine);
                Thread.Sleep(500);
            }
        }
        //you can also pass a result from this method back to the GUI thread like this
        //e.Result = "job done";
        //this can be read later in RunWorkerCompleted method of the BackgroundWorker
        }
