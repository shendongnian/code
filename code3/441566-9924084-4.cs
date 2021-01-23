    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    
    namespace AClient
    {
        public class Materiel
        {
            public string A { get; set; }
            public int B { get; set; }
            public DateTime? C { get; set; }
            public string D { get; set; }
            public Nested E { get; set; }
        }
    
        public struct Nested
        {
            public string Data { get; set; }
            public override string ToString() { return string.Format("Extra: {0}", Data); }
        }
    
    
        public static class FullText
        {
            public class PropMatched<T> { public PropertyInfo Property; public T Item; }
    
            public static IEnumerable<PropMatched<T> > ByProperty<T>(this IEnumerable<T> items, string substr)
            {
                return items.ByProperty(new Regex(Regex.Escape(substr), RegexOptions.IgnoreCase));
            }
    
            public static IEnumerable<PropMatched<T> > ByProperty<T>(this IEnumerable<T> items, Regex pattern)
            {
                return items.Select(i => i.MatchingProperties(pattern)).Where(m => null != m);
            }
    
            public static IEnumerable<T> Search<T>(this IEnumerable<T> items, string substr)
            {
                return items.Search(new Regex(Regex.Escape(substr), RegexOptions.IgnoreCase));
            }
    
            public static IEnumerable<T> Search<T>(this IEnumerable<T> items, Regex pattern)
            {
                return items.Where(i => null != i.MatchingProperties(pattern));
            }
    
            public static PropMatched<T> MatchingProperties<T>(this T item, Regex pattern)
            {
                if (null == pattern || null == item) return null;
    
                var properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
                var matches = from   prop in properties 
                              let    val = prop.GetGetMethod(true).Invoke(item, new object[]{}) 
                              where  pattern.IsMatch((val??"").ToString()) 
                              select prop;
    
                var found = matches.FirstOrDefault();
                return found == null ? null : new PropMatched<T> {Item = item, Property = found};
            }
        }
    
        class Client
        {
            private static readonly IEnumerable<Materiel> Database = new List<Materiel>
                {
                    new Materiel {
                            A = "Hello", B = 1, C = null, D = "World",
                            E = new Nested {Data = "Attachment"}
                        },
                    new Materiel {
                            A = "Transfigured", B = 2, C = null, D = "Nights",
                            E = new Nested {Data = "Schoenberg"}
                        },
                    new Materiel {
                            A = "Moby", B = 3, C = null, D = "Dick",
                            E = new Nested {Data = "Biographic"}
                        },
                    new Materiel {
                            A = "Prick", B = 4, C = DateTime.Today, D = "World",
                            E = new Nested {Data = "Attachment"}
                        },
                    new Materiel {
                            A = "Oh Noes", B = 2, C = null, D = "Nights",
                            E = new Nested {Data = "Schoenberg"}
                        },
                };
    
    
            static void Main()
            {
                foreach (var pattern in new[]{ "World" , "dick", "Dick", "ick", "2012", "Attach" })
                    Console.WriteLine("{0} records match '{1}'", Database.Search(pattern).Count(), pattern);
    
                // regex sample:
                var regex = new Regex(@"N\w+s", RegexOptions.IgnoreCase);
    
                Console.WriteLine(@"{0} records match regular expression 'N\w+s'", Database.Search(regex).Count());
    
                // with context info:
                foreach (var contextMatch in Database.ByProperty(regex))
                {
                    Console.WriteLine("1 match of regex in propery {0} with value '{1}'",
                        contextMatch.Property.Name, contextMatch.Property.GetGetMethod().Invoke(contextMatch.Item, new object[0]));
    
                }
            }
        }
    }
