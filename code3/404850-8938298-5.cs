        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            String text = e.Argument as String;
            List<String> results = new List<string>();
            //Code for seraching text - may be diffrent if you have another DataSource 
            foreach (String dataString in DataSource)
            {
                if (dataString.IndexOf(text, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    results.Add(dataString);
                }
            }
            e.Result = results;
        }
