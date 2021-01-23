    public void produceConsume()
    {
        var results = new BlockingCollection<double[]>();
        var producer = Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                var data = new double[1024];
                results.Add(data);                    
            }
            results.CompleteAdding();
        });
        var consumer = Task.Factory.StartNew(() =>
        {
            foreach (var item in results.GetConsumingEnumerable())
            {
               // put in chart
            }
        });
        producer.Wait();
    }
