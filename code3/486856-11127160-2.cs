      private void Form1_Load(object sender, EventArgs e)
                  DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
            // create a list to insert the data into
            //put all the files in the root directory into array
            string[] fileEntries = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.csv");
            // Display all files.
            TextWriter tw1 = new StreamWriter(folderBrowserDialog1.SelectedPath + "/listoffiles.txt");
            List<string> filenames = new List<string>();
            tw1.WriteLine("--- Files: ---");
            foreach (string path in fileEntries)
            {
                tw1.WriteLine(path);
            }
            tw1.Close();
            TextWriter tw2 = new StreamWriter(folderBrowserDialog1.SelectedPath + "/errorlist.txt");
            foreach (string path in fileEntries)
            {
                string text = "";
                // create a list to insert the data into
                List<float> noise = new List<float>();
                TextWriter tw3 = new StreamWriter(folderBrowserDialog1.SelectedPath + "/rawdata.txt");
                string file = path;
                FileInfo src = new FileInfo(file);
                TextReader reader = src.OpenText();
                text = reader.ReadLine();
                // while the text being read in from reader.Readline() is not null
                while (text != null)
                {
                    string[] words = text.Split(',');
                    noise.Add(Convert.ToSingle(words[3]));
                    // write text to a file
                    tw3.WriteLine(text);
                    text = reader.ReadLine();
                }
                tw3.Close();
                int count = 0;
                float sum = 0;
                float mean = 0;
                float max = 0;
                float min = 100;
                List<string> means = new List<string>();
                List<string> maximums = new List<string>();
                List<string> minimums = new List<string>();
                TextWriter tw4 = new StreamWriter(folderBrowserDialog1.SelectedPath + "/noise.txt");
                foreach (float ns in noise)
                {
                    tw4.WriteLine(Convert.ToString(ns));
                    count++;
                    sum += ns;
                    mean = sum / count;
                    float min1 = 0;
                    if (ns > max)
                        max = ns;
                    else if (ns < max)
                        min1 = ns;
                    if (min1 < min && min1 > 0)
                        min = min1;
                    means.Add(Convert.ToString(mean));
                    maximums.Add(Convert.ToString(max));
                    minimums.Add(Convert.ToString(min));
                }
                TextWriter tw5 = new StreamWriter(folderBrowserDialog1.SelectedPath + "/summarymeans.txt");
                tw5.WriteLine("Mean Noise");
                tw5.WriteLine("==========");
                foreach (string m in means)
                {
                    tw5.WriteLine("mote_noise: {0}", Convert.ToString(m));
                }
                tw5.Close();
                TextWriter tw6 = new StreamWriter(folderBrowserDialog1.SelectedPath + "/summarymaximums.txt");
                tw6.WriteLine("Maximum Noise");
                tw6.WriteLine("=============");
                foreach (string m in maximums)
                {
                    tw6.WriteLine("mote_noise: {0}", Convert.ToString(m));
                }
                tw6.Close();
                TextWriter tw7 = new StreamWriter(folderBrowserDialog1.SelectedPath + "/summaryminimums.txt");
                tw7.WriteLine("Minimum Noise");
                tw7.WriteLine("=============");
                foreach (string m in maximums)
                {
                    tw7.WriteLine("mote_noise: {0}", Convert.ToString(m));
                }
                tw7.Close();
                tw4.Close();
            }
            tw2.Close();
     }
