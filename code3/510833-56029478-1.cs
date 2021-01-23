    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Caching;
    
    namespace TestListPerformance
    {
        class Program
        {
            static void Main(string[] args) {
                var summary = BenchmarkRunner.Run<BenchmarkMemoryCache>();
            }
        }
    
        public class BenchmarkMemoryCache
        {
            [Params(30000)]
            public int N { get; set; }
            public string FindStr;
            private IList<DadosEmp> data;
            private Dictionary<string, DadosEmp> dict;
            private ConcurrentDictionary<string, DadosEmp> concurrentDict;
            private HashSet<DadosEmp> hashset;
            private DadosEmp last;
    
            [GlobalSetup]
            public void BuildData() {
                FindStr = N.ToString();
                data = new List<DadosEmp>(N);
                dict = new Dictionary<string, DadosEmp>(N);
                concurrentDict = new ConcurrentDictionary<string, DadosEmp>();
                hashset = new HashSet<DadosEmp>();
                for (int i = 0; i <= N; i++) {
                    DadosEmp d;
                    data.Add(d = new DadosEmp {
                        Identificacao = i,
                        Pis = i * 100,
                        NumCartao = i * 1000,
                        Nome = "Nome " + i.ToString(),
                    });
                    MemoryCache.Default.Add(i.ToString(), d, 
                        new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(30) });
                    dict.Add(i.ToString(), d);
                    concurrentDict.TryAdd(i.ToString(), d);
                    hashset.Add(d);
                    last = d;
                }
            }
            [Benchmark]
            public DadosEmp FindDadosEmpInCache() {
                var f = (DadosEmp)MemoryCache.Default.Get(FindStr);
                return f;
            }
            [Benchmark]
            public DadosEmp FindDataAtTheEnd() {
                var f = data.FirstOrDefault(e => e.NumCartao == N || e.Pis == N || e.Identificacao == N);
                return f;
            }
            [Benchmark]
            public DadosEmp FindDataInDictionary() {
                var f = dict[FindStr];
                return f;
            }
            [Benchmark]
            public DadosEmp FindDataInConcurrentDictionary() {
                var f = concurrentDict[FindStr];
                return f;
            }
            [Benchmark]
            public bool FindDataInHashset() {
                return hashset.Contains(last);
            }
    
        }
    
        public class DadosEmp : IEquatable<DadosEmp> 
        {
            public const string BIO_EXCLUSAO = "xbio";
    
            public DadosEmp() {
                Biometrias = new List<string>();
            }
            public long Identificacao { get; set; }
            public long Pis { get; set; }
            public long NumCartao { get; set; }
            public string Nome { get; set; }
            public int VersaoBio { get; set; }
            public string Unidade { get; set; }
            public IList<string> Biometrias { get; set; }
            public string Biometria { get; set; } 
            public bool ExcluirBiometria { get { return Biometria == BIO_EXCLUSAO; } }
            public DateTime DataEnvioRep { get; set; } 
            public string SenhaTeclado { get; set; }
            public bool ExigeAutorizacaoSaida { get; set; }
            public bool BioRepPendente { get; set; }
            public override bool Equals(object obj) {
                DadosEmp e = obj as DadosEmp;
                if (ReferenceEquals(e, null))
                    return false;
                return Equals(e);
            }
            public bool Equals(DadosEmp e) {
                if (ReferenceEquals(e, null))
                    return false;
                return e.Pis == this.Pis;
            }
            public override int GetHashCode() {
                return Pis.GetHashCode();
            }
            public override string ToString() {
                return string.Format("{0} ({1} - {2})", Nome, Pis, Identificacao);
            }
        }
    }
