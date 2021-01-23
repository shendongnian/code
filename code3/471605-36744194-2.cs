    namespace UnitTest
    {
        public static class ExpressiveAnnotationTestHelpers
        {
            public static IEnumerable<ExpressiveAttribute> CompileExpressiveAttributes(this Type type)
            {
                var properties = type.GetProperties()
                    .Where(p => Attribute.IsDefined(p, typeof(ExpressiveAttribute)));
                var attributes = new List<ExpressiveAttribute>();
                foreach (var prop in properties)
                {
                    var attribs = prop.GetCustomAttributes<ExpressiveAttribute>().ToList();
                    attribs.ForEach(x => x.Compile(prop.DeclaringType));
                    attributes.AddRange(attribs);
                }
                return attributes;
            }
        }
        [TestClass]
        public class ExpressiveAnnotationTests
        {
            [TestMethod]
            public void CompileAnnotationsTest()
            {
                // ... or for all assemblies within current domain:
                var compiled = Assembly.Load("NamespaceOfEntitiesWithExpressiveAnnotations").GetTypes()
                    .SelectMany(t => t.CompileExpressiveAttributes()).ToList();
    
                Console.WriteLine($"Total entities using Expressive Annotations: {compiled.Count}");
    
                foreach (var compileItem in compiled)
                {
                    Console.WriteLine($"Expression: {compileItem.Expression}");
                }
    
                Assert.IsTrue(compiled.Count > 0);
            }
    
    
        }
    }
