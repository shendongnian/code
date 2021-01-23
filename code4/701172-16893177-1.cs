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
                //                     Building ID ↓               ↓ Improvement ID
                var byBuildingId = new Dictionary<int, Dictionary<int, Result>>();
                for (int buildingKey = 1000; buildingKey < 2000; ++buildingKey)
                {
                    var improvements = new Dictionary<int, Result>();
                    for (int improvementKey = 5000; improvementKey < 5030; ++improvementKey)
                        improvements.Add(improvementKey, new Result{ Data = buildingKey + improvementKey/1000.0 });
                    byBuildingId.Add(buildingKey, improvements);
                }
                //                      Improvment ID ↓               ↓ Building ID
                var byImprovementId = new Dictionary<int, Dictionary<int, Result>>();
                foreach (var improvements in byBuildingId)
                {
                    foreach (var improvement in improvements.Value)
                    {
                        if (!byImprovementId.ContainsKey(improvement.Key))
                            byImprovementId[improvement.Key] = new Dictionary<int, Result>();
                        byImprovementId[improvement.Key].Add(improvements.Key, improvement.Value);
                    }
                }
                // Aggregate data for all improvements for building with ID == 1500:
                int buildingId = 1500;
                var sum = byBuildingId[buildingId].Sum(result => result.Value.Data);
                Console.WriteLine(sum);
                // Aggregate data for all buildings with a given improvement.
                int improvementId = 5010;
                sum = byBuildingId.Sum(improvements =>
                {
                    Result result;
                    return improvements.Value.TryGetValue(improvementId, out result) ? result.Data : 0.0;
                });
                Console.WriteLine(sum);
                // Aggregate data for all buildings with a given improvement using byImprovementId:
                sum = byImprovementId[improvementId].Sum(result => result.Value.Data);
                Console.WriteLine(sum);
            }
            static void Main()
            {
                new Program().run();
            }
        }
        static class DemoUtil
        {
            public static void Print(this object self)
            {
                Console.WriteLine(self);
            }
            public static void Print(this string self)
            {
                Console.WriteLine(self);
            }
            public static void Print<T>(this IEnumerable<T> self)
            {
                foreach (var item in self)
                    Console.WriteLine(item);
            }
        }
    }
                                                                              
                                                                              
