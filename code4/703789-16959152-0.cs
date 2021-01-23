    using System;
    using System.Collections.Generic;
    
    public class Sample {
        public static void Main(String[] args) {
            var n8  = toFactors(8);
            var n12 = toFactors(12);
            var uf = unionFactors(n8, n12);//LCM
            printFactors(uf);
        }
        public static void printFactors(Dictionary<long, int> factors){
            Console.Write("{ ");
            foreach(var factor in factors.Keys){
                for(int i=0;i<factors[factor];++i)
                    Console.Write( factor + " ");
            }
            Console.WriteLine("}");
        }
        public static Dictionary<long, int> unionFactors(Dictionary<long, int> af, Dictionary<long, int> bf){
            Dictionary<long, int> uf = new Dictionary<long, int>();
            foreach(var kv in af){
                uf.Add(kv.Key, kv.Value);//copy
            }
            foreach(var kv in bf){
                if(uf.ContainsKey(kv.Key)){
                    if(kv.Value > uf[kv.Key])//max
                        uf[kv.Key] = kv.Value;
                } else {
                    uf.Add(kv.Key, kv.Value);
                }
            }
            return uf;
        }
        public static Dictionary<long, int> toFactors(long num){
            var factors = new Dictionary<long, int>();
            long n = num, i = 2, sqi = 4;
            while(sqi <= n){
                while(n % i == 0){
                    n /= i;
                    if(factors.ContainsKey(i)){
                        factors[i] += 1;
                    } else {
                        factors.Add(i, 1);
                    }
                }
                sqi += 2 * (i++) + 1;
            }
            if(n != 1 && n != num){
                if(factors.ContainsKey(i)){
                    factors[i] += 1;
                } else {
                    factors.Add(i, 1);
                }
            }
            if(factors.Count == 0)
                factors.Add(num, 1);//prime
            return factors;
        }
    }
