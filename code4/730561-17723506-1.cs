            int N = 1000;                                    
            string dataFile = "data.txt";                  // one data file
            string gnuplotScript = "gnuplotScript.plt";    // gnuplot script
            string pngFile = "trajectory.png";             // output png file
            // init values
            double x = 0, y = 0;
            // random values to plot
            Random rnd = new Random();
            StreamWriter sw = new StreamWriter(dataFile);
            // US output standard
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            // generate data for visualisation       
            for (int i = 0; i < N; i++)
            {
                x += rnd.NextDouble() - 0.5;
                y += rnd.NextDouble() - 0.5;
                sw.WriteLine(x.ToString("F3") + "\t" + y.ToString("F3"));
            }
            sw.Close();
            // you can download it from file
            string gnuplot_script = "set encoding utf8\n" +
                                    "set title \"Random trajectory\"\n" +
                                    "set xlabel \"Coordinate X\"\n" +
                                    "set ylabel \"Coordinate Y\"\n" +
                                    "set term pngcairo size 1024,768 font \"Arial,14\"\n" +
                                    "set output \"pngFile\"\n" +
                                    "plot 'dataFile' w l notitle\n" +
                                    "end";
            // change filenames in script
            gnuplot_script = gnuplot_script.Replace("dataFile", dataFile);
            gnuplot_script = gnuplot_script.Replace("pngFile", pngFile);
          
            // write sccript to file
            sw = new StreamWriter(gnuplotScript, false, new System.Text.UTF8Encoding(false));
            sw.WriteLine(gnuplot_script);
            sw.Close();
            // launch script
            ProcessStartInfo PSI = new ProcessStartInfo();
            PSI.FileName = gnuplotScript;
            string dir = Directory.GetCurrentDirectory();
            PSI.WorkingDirectory = dir;
            using (Process exeProcess = Process.Start(PSI))
            {
                exeProcess.WaitForExit();
            }
            // OPTION: launch deafault program to see file
            PSI.FileName = pngFile;
            using (Process exeProcess = Process.Start(PSI))
            {
            }
        
