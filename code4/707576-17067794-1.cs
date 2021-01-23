    private void Foo()
    {
        //NET OIL VARIANCE MATHEMATICS
        if (netOilRadBtn.Checked)
        {
            var input = new List<MyData>(); // <-- Fill in your data here.
            StreamWriter sw = new StreamWriter("testNetOil.csv");
            sw.WriteLine(MyData.GetHeaders());
            //Loops until the end of the list, printing out info
            foreach (var item in input)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }
    }
