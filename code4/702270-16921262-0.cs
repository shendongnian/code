    private void netOilRadBtn_CheckedChanged(object sender, EventArgs e)
    {
        using (var sw = new StreamWriter("test.txt")) //testing purposes only
        { 
            //StreamReader sr = new StreamReader("OUTPUT.CSV");
            double first;
            double second;
            foreach (var i in netOil2.Zip(seqNum2, (oil, seq) => new {Oil = oil, Seq = seq}))
            {
               foreach (var j in netOil.Zip(seqNum, (oil, seq) => new {Oil = oil, Seq = seq}))
               {
                   if (j.Seq = i.Seq)
                   {
                        //sw.WriteLine("Find New Seq Num");
                        first = Convert.ToDouble(i.Oil);
                        second = Convert.ToDouble(j.Oil);
                        double answer = (first - second) / first;
                        sw.WriteLine("{0}, {1}", j.Seq, answer);
                   }
                }
            }
        }
    }
