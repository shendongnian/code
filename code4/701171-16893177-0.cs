    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace Demo
    {
        sealed class Result
        {
            public double Data;
        }
        sealed class Building
        {
            public int Id;
            public int Value;
        }
        sealed class Improvement
        {
            public int Id;
            public int Value;
        }
        class Program
        {
            void run()
            {
                //             Building ID ↓               ↓ Improvement ID
                var data = new Dictionary<int, Dictionary<int, Result>>();
                for (int buildingKey = 1000; buildingKey < 2000; ++buildingKey)
                {
                    var improvements = new Dictionary<int, Result>();
                    for (int improvementKey = 5000; improvementKey < 5030; ++improvementKey)
                        improvements.Add(improvementKey, new Result{ Data = buildingKey + improvementKey/1000.0 });
                    data.Add(buildingKey, improvements);
                }
                // Aggregate data for all improvements for building with ID == 1500:
                int buildingId = 1500;
                var sum = data[buildingId].Sum(result => result.Value.Data);
                Console.WriteLine(sum);
                // Aggregate data for all buildings with a given improvement.
                int improvementId = 5010;
                sum = data.Sum(improvements =>
                {
                    Result result;
                    return improvements.Value.TryGetValue(improvementId, out result) ? result.Data : 0.0;
                });
                Console.WriteLine(sum);
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
