    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections.Generic;
    namespace Demo
    {
        sealed class Result
        {
            public double Data;
        }
        sealed class BuildingId
        {
            public BuildingId(int id)
            {
                Id = id;
            }
            public readonly int Id;
        
            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                var other = obj as BuildingId;
                if (other == null)
                    return false;
                return this.Id == other.Id;
            }
        }
        sealed class ImprovementId
        {
            public ImprovementId(int id)
            {
                Id = id;
            }
            public readonly int Id;
            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                var other = obj as ImprovementId;
                if (other == null)
                    return false;
                return this.Id == other.Id;
            }
        }
        sealed class Building
        {
            public BuildingId Id;
            public int Value;
        }
        sealed class Improvement
        {
            public ImprovementId Id;
            public int Value;
        }
        sealed class BuildingResults : Dictionary<BuildingId, Result>{}
        sealed class ImprovementResults: Dictionary<ImprovementId, Result>{}
        sealed class BuildingsById: Dictionary<BuildingId, ImprovementResults>{}
    
        sealed class ImprovementsById: Dictionary<ImprovementId, BuildingResults>{}
        class Program
        {
            void run()
            {
                var byBuildingId    = CreateTestBuildingsById();            // Create some test data.
                var byImprovementId = CreateImprovementsById(byBuildingId); // Create the alternative lookup dictionaries.
                var testTuples      = CreateTestTuples();
                ImprovementId improvementId = new ImprovementId(5010);
                int count = 10000;
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    byImprovementId[improvementId].Sum(result => result.Value.Data);
                Console.WriteLine("Dictionary of dictionaries took " + sw.Elapsed);
                sw.Restart();
                for (int i = 0; i < count; ++i)
                    testTuples.Where(result => result.Key.Item2.Equals(improvementId)).Sum(item => item.Value.Data);
                Console.WriteLine("Dictionary of tuples took " + sw.Elapsed);
            }
            static Dictionary<Tuple<BuildingId, ImprovementId>, Result> CreateTestTuples()
            {
                var result = new Dictionary<Tuple<BuildingId, ImprovementId>, Result>();
                for (int buildingKey = 1000; buildingKey < 2000; ++buildingKey)
                    for (int improvementKey = 5000; improvementKey < 5030; ++improvementKey)
                        result.Add(
                            new Tuple<BuildingId, ImprovementId>(new BuildingId(buildingKey), new ImprovementId(improvementKey)),
                            new Result
                            {
                                Data = buildingKey + improvementKey/1000.0
                            });
                return result;
            }
            static BuildingsById CreateTestBuildingsById()
            {
                var byBuildingId = new BuildingsById();
                for (int buildingKey = 1000; buildingKey < 2000; ++buildingKey)
                {
                    var improvements = new ImprovementResults();
                    for (int improvementKey = 5000; improvementKey < 5030; ++improvementKey)
                    {
                        improvements.Add
                        (
                            new ImprovementId(improvementKey),
                            new Result
                            {
                                Data = buildingKey + improvementKey/1000.0
                            }
                        );
                    }
                    byBuildingId.Add(new BuildingId(buildingKey), improvements);
                }
                return byBuildingId;
            }
            static ImprovementsById CreateImprovementsById(BuildingsById byBuildingId)
            {
                var byImprovementId = new ImprovementsById();
                foreach (var improvements in byBuildingId)
                {
                    foreach (var improvement in improvements.Value)
                    {
                        if (!byImprovementId.ContainsKey(improvement.Key))
                            byImprovementId[improvement.Key] = new BuildingResults();
                        byImprovementId[improvement.Key].Add(improvements.Key, improvement.Value);
                    }
                }
                return byImprovementId;
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
