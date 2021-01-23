     class Rewriter : SyntaxRewriter
            {
                SemanticModel model { get; set; }
                IEnumerable<Diagnostic> diagonists;
    
     public Rewriter(SemanticModel pModel)
                {
                    model = pModel;             
                    diagonists = pModel.GetDiagnostics();
                }
    
            }
