    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.TeamFoundation;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using System.Collections;
    using System.Threading.Tasks;
    using System.Diagnostics;
    namespace QueryHistoryPerformanceTesting
    {
        class Program
        {
            static string TFS_COLLECTION = /* TFS COLLECTION URL */
            static VersionControlServer GetTfsClient()
            {
                var projectCollectionUri = new Uri(TFS_COLLECTION);
                var projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(projectCollectionUri, new UICredentialsProvider());
                projectCollection.EnsureAuthenticated();
                return projectCollection.GetService<VersionControlServer>();
            }
            
            struct ThrArg
            {
                public VersionControlServer tfc { get; set; }
                public string path { get; set; }
            }
            static List<string> PATHS = new List<string> {
                // ASSUME 21 FILE PATHS
            };
            static int NUM_RUNS = 5;
            static void Main(string[] args)
            {
                var results = new List<TimeSpan>();
                for (int i = NUM_RUNS; i > 0; i--)
                {
                    results.Add(RunTestParallelPreAlloc());
                }
                Console.WriteLine("Parallel Pre-Alloc: Execution Time Average (ms): " + results.Select(t => t.TotalMilliseconds).Average());
                results.Clear();
                for (int i = NUM_RUNS; i > 0; i--)
                {
                    results.Add(RunTestParallelAllocOnDemand());
                }
                Console.WriteLine("Parallel AllocOnDemand: Execution Time Average (ms): " + results.Select(t => t.TotalMilliseconds).Average());
                
                results.Clear();
                for (int i = NUM_RUNS; i > 0; i--)
                {
                    results.Add(RunTestParallelSameClient());
                }
                Console.WriteLine("Parallel-SameClient: Execution Time Average (ms): " + results.Select(t => t.TotalMilliseconds).Average());
                results.Clear();
                for (int i = NUM_RUNS; i > 0; i--)
                {
                    results.Add(RunTestSerial());
                }
                Console.WriteLine("Serial: Execution Time Average (ms): " + results.Select(t => t.TotalMilliseconds).Average());
            }
            static TimeSpan RunTestParallelPreAlloc()
            {
                var paths = new List<ThrArg>();
                paths.AddRange( PATHS.Select( x => new ThrArg { path = x, tfc = GetTfsClient() } ) );
                return RunTestParallel(paths);
            }
            static TimeSpan RunTestParallelAllocOnDemand()
            {
                var paths = new List<ThrArg>();
                paths.AddRange(PATHS.Select(x => new ThrArg { path = x, tfc = null }));
                return RunTestParallel(paths);
            }
            static TimeSpan RunTestParallelSameClient()
            {
                var paths = new List<ThrArg>();
                var _tfc = GetTfsClient();
                paths.AddRange(PATHS.Select(x => new ThrArg { path = x, tfc = _tfc }));
                return RunTestParallel(paths);
            }
            static TimeSpan RunTestParallel(List<ThrArg> args)
            {
                var allIds = new List<int>();
                
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Parallel.ForEach(args, s =>
                {
                    allIds.AddRange(GetIdsFromHistory(s.path, s.tfc));
                }
                );
                stopWatch.Stop();
                return stopWatch.Elapsed;
            }
            
            static TimeSpan RunTestSerial()
            {
                var allIds = new List<int>();
                VersionControlServer tfsc = GetTfsClient();
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                foreach (string s in PATHS)
                {
                    allIds.AddRange(GetIdsFromHistory(s, tfsc));
                }
                stopWatch.Stop();
                return stopWatch.Elapsed;
            }
            static List<int> GetIdsFromHistory(string path, VersionControlServer tfsClient)
            {
                if (tfsClient == null)
                {
                    tfsClient = GetTfsClient();
                }
                IEnumerable submissions = tfsClient.QueryHistory(
                    path,
                    VersionSpec.Latest,
                    0,
                    RecursionType.None, // Assume that the path is to a file, not a directory
                    null,
                    null,
                    null,
                    Int32.MaxValue,
                    false,
                    false);
                List<int> ids = new List<int>();
                foreach(Changeset cs in submissions)
                {
                    ids.Add(cs.ChangesetId);
                }
                return ids;
            }
