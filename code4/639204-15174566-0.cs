        void writeFile()
        {
            for (int k = 0; k < 10000; k++)
            {
                int irTempPara = k;
                Task.Factory.StartNew(() =>
                {
                    writeFileForReal(irTempPara);
                }, TaskCreationOptions.LongRunning); // this way you do not need sleep
                // System.Threading.Thread.Sleep(10);
            }
        }
