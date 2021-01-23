    static void Main(string[] args)
    {
        var reader=System.IO.File.OpenText("Data.csv");
        List<double[]> data=new List<double[]>();
        var line=reader.ReadLine();
        double max=0;
        while(!reader.EndOfStream)
        {
            line=reader.ReadLine();
            string[] parts=line.Split(',');
            //parse first part as date
            DateTime date=DateTime.Parse(parts[0]);
            //parse rest of parts as float/doulbe/decimal
            double[] values=new double[parts.Length-1];
            for(int i=0; i<values.Length; i++)
            {
                //for each value in row convert string to number safely.
                double x = 0;
                double.TryParse(parts[i+1], out x);
                values[i]=x;
            }
            //keep data values in list
            data.Add(values);
            //keep highest from 1st column
            if(values[0]>max) { max=values[0]; }
        }
        reader.Close();
    }
