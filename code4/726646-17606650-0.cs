    private void LoadTermCodes(TextBox tb)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        StreamReader sr = new StreamReader(@"xxx.txt");
        string line;
    
        // initialise the StringBuilder
        System.Text.StringBuilder outputBuilder = new System.Text.StringBuilder(String.Empty);
        while ((line = sr.ReadLine()) != null)
        {
            string[] colums = line.Split('\t');
            var id = colums[4];
            var diagnosisName = colums[7];
    
            if (dic.Keys.Contains(id))
            {
                var temp = dic[id];
                temp += "," + diagnosisName;
                dic[id] = temp;
            }
            else
            {
                dic.Add(id, diagnosisName);
            }
        }
    
        sw.Stop();
        long spentTime = sw.ElapsedMilliseconds;
    
        foreach (var element in dic)
        {
            // append a line to it, this will stop a lot of the copying
            outputBuilder.AppendLine(String.Format("{0}\t{1}", element.Key, element.Value));
        }
    
        // emit the text
        tb.Text += outputBuilder.ToString();
        
        MessageBox.Show("Jie shu le haha~~~ " + spentTime);
    }
