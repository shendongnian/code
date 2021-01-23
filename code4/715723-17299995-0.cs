    IEnumerable<DataPoint> FilterInitialDecreasing(IEnumerable<DataPoint> items)
    {
        var buffer = new Queue<DataPoint>();
        int increasingCount = 0;
        int prior = int.MinValue;
        foreach (int data in items.DataPoints)
        {
            switch(increasingCount)
            {
               case 2:
            {
                yield return data;
            }
            else if (data.Length > prior)
            {
               increasingCount++;
               prior = data.Length;
               buffer.EnQueue(data);
               if (increasingCount >2)
               {
                   yield return Queue.Dequeue();
                   yield return Queue.Dequeue();
                   yield return data;
               }
            }
            else
            {
               increasingCount = 0;
               buffer = new Queue<DataPoint>();
               prior = int.MinValue;
            }
        }
    }
