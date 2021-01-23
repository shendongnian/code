    private void netOilRadBtn_CheckedChanged(object sender, EventArgs e)
    {
        using (var sw = new StreamWriter("test.txt")) //testing purposes only
        { 
            //StreamReader sr = new StreamReader("OUTPUT.CSV");
            var items =  netOil.Zip(seqNum, (oil, seq) => new {Oil = oil, Seq = seq});
            var items2 =  netOil2.Zip(seqNum2, (oil, seq) => new {Oil = oil, Seq = seq});
             
            foreach (var item in items.Join(items2,
                         i=>i.Seq,i=>i.Seq, (a,b)=>
                         {
                             double first = Convert.ToDouble(netOil2[i]);
                             double second = Convert.ToDouble(netOil[j]);
                             double answer = (first - second) / first;
                             return string.Format("{0}, {1}", a.Seq, answer);
                         }))
            { 
                sw.WriteLine(item);
            }
        }
    }
