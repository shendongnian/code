     var solution =
                Solution.Create(SolutionId.CreateNewId())
                        .AddCSharpProject(Title, Title, out projectId)
                        .AddMetadataReference(projectId, MetadataReference.CreateAssemblyReference("mscorlib"))
                        .AddMetadataReference(projectId, MetadataReference.CreateAssemblyReference("Microsoft.CSharp"))
                        .AddMetadataReference(projectId, MetadataReference.CreateAssemblyReference("System"))
                        .AddMetadataReference(projectId, MetadataReference.CreateAssemblyReference("System.Core"))
                        .AddMetadataReference(projectId, MetadataReference.CreateAssemblyReference("System.Web"))
                        .AddDocument(projectId, "MyFile.cs",
                            @"using System;
                            using System.Web;
                            using System.Web.UI;
    
                            public partial class _Default : Page
                            {
                                protected void Page_Load(object sender, EventArgs e, string s)
                                {
                                    Response.Write(""hello"");
                                }
                            }"
                        , out documentId);
    
    
    
                var mydocument = solution.GetDocument(documentId);
                var tree = mydocument.GetSyntaxTree();
                SemanticModel model = (SemanticModel)mydocument.GetSemanticModel();
    
                var responseWriteLine = tree.GetRoot().DescendantNodes().OfType<InvocationExpressionSyntax>().First();
                Assert.IsNotNull(model.GetSymbolInfo(responseWriteLine.Expression).Symbol);
