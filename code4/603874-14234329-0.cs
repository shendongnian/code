        var d = XDocument.Parse(testXml);
        var r = d.Element("table");
        var listOfDoubleArrays = new List<double[]>();
        foreach (var outerArrayItem in r.Elements())
        {
            double[] arr = new double[r.Elements().Count()];
            int i = 0;
            foreach (var innerArrayItem in outerArrayItem.Elements())
            {
                arr[i] = System.Convert.ToDouble(innerArrayItem.Value);
                i++;
            }
            listOfDoubleArrays.Add(arr);
        }
        double[][] result = listOfDoubleArrays.ToArray();
