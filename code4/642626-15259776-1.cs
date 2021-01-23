    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class RuleSelection{
        public int RuleId { get; set;}
        public int? CriteriaId { get; set; }
        public int? CriteriaSourceId{ get; set; }
    }
    
    public class Rule{
        public int RuleId { get; set; }
        public IEnumerable<int> Criteria { get; set; }
        public IEnumerable<int> CriteriaSource { get; set; }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<RuleSelection> theRules = new List<RuleSelection>
            {
                new RuleSelection { RuleId = 42, CriteriaId = 1 },
                new RuleSelection { RuleId = 42, CriteriaSourceId = 1 },
                new RuleSelection { RuleId = 42, CriteriaId = 2 },
                new RuleSelection { RuleId = 43, CriteriaSourceId = 3 },
            };
    
            theRules.FullOuterGroupJoin(theRules,
                    r => r.RuleId,
                    r => r.RuleId,
                    (crit, critSource, id) => new Rule { 
                        RuleId = id, 
                        Criteria = crit
                            .Where(r => r.CriteriaId.HasValue)
                            .Select(r => r.CriteriaId.Value),
                        CriteriaSource = critSource
                            .Where(r => r.CriteriaSourceId.HasValue)
                            .Select(r => r.CriteriaSourceId.Value),
                        //CriteriaSource = critSource.Except(new[]{null}) 
                    }
                );
    
        }
    }
    
    internal static class MyExtensions
    {
        internal static IList<TR> FullOuterGroupJoin<TA, TB, TK, TR>(
            this IEnumerable<TA> a,
            IEnumerable<TB> b,
            Func<TA, TK> selectKeyA, Func<TB, TK> selectKeyB,
            Func<IEnumerable<TA>, IEnumerable<TB>, TK, TR> projection)
        {
            var alookup = a.ToLookup(selectKeyA);
            var blookup = b.ToLookup(selectKeyB);
    
            var keys = new HashSet<TK>(alookup.Select(p => p.Key));
            keys.UnionWith(blookup.Select(p => p.Key));
    
            var join = from key in keys
                       let xa = alookup[key]
                       let xb = blookup[key]
                       select projection(xa, xb, key);
    
            return join.ToList();
        }
    
        internal static IList<TR> FullOuterJoin<TA, TB, TK, TR>(
            this IEnumerable<TA> a,
            IEnumerable<TB> b,
            Func<TA, TK> selectKeyA, Func<TB, TK> selectKeyB,
            Func<TA, TB, TK, TR> projection,
            TA defaultA = default(TA), TB defaultB = default(TB))
        {
            var alookup = a.ToLookup(selectKeyA);
            var blookup = b.ToLookup(selectKeyB);
    
            var keys = new HashSet<TK>(alookup.Select(p => p.Key));
            keys.UnionWith(blookup.Select(p => p.Key));
    
            var join = from key in keys
                       from xa in alookup[key].DefaultIfEmpty(defaultA)
                       from xb in blookup[key].DefaultIfEmpty(defaultB)
                       select projection(xa, xb, key);
    
            return join.ToList();
        }
    }
