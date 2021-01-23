    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;
    using Roslyn.Services;
    using Roslyn.Services.CSharp;
    using Roslyn.Compilers.Common;
    
    class Program
    {
        static void Main(string[] args)
        {
            var code = @"enum E { V } class { static void Main() { string s = ""Value: "" + E.V; } }";
            var doc = Solution.Create(SolutionId.CreateNewId())
                .AddCSharpProject("foo", "foo")
                .AddMetadataReference(MetadataFileReference.CreateAssemblyReference("mscorlib"))
                .AddDocument("doc.cs", code);
            var stringType = doc.Project.GetCompilation().GetSpecialType(SpecialType.System_String);
            var e = doc.Project.GetCompilation().GlobalNamespace.GetTypeMembers("E").Single();
            var v = e.GetMembers("V").Single();
            var refs = v.FindReferences(doc.Project.Solution);
            var toStrings = from referencedLocation in refs
                            from r in referencedLocation.Locations
                            let node = GetNode(doc, r.Location)
                            let convertedType = doc.GetSemanticModel().GetTypeInfo(GetNode(doc, r.Location)).ConvertedType
                            where convertedType.Equals(stringType)
                            select r.Location;
            foreach (var loc in toStrings)
            {
                Console.WriteLine(loc);
            }
        }
    
        static CommonSyntaxNode GetNode(IDocument doc, CommonLocation loc)
        {
            return loc.SourceTree.GetRoot().FindToken(loc.SourceSpan.Start).Parent.Parent.Parent;
        }
    }
