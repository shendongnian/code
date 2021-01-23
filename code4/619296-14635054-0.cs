    //...
    using Microsoft.Xna.Framework.Content.Pipeline;
    class PSSourceCode
    {
        const string techniqueCode = "{ pass p0 { PixelShader = compile ps_2_0 main(); } }";
    
        public PSSourceCode(string sourceCode, string techniqueName)
        {
            this.sourceCode = sourceCode + "\ntechnique " + techniqueName + techniqueCode;
        }
    
        private string sourceCode;
        public string SourceCode { get { return sourceCode; } }
    }
    
    [ContentImporter(".psh", DefaultProcessor = "PSProcessor", DisplayName = "Pixel Shader Importer")]
    class PSImporter : ContentImporter<PSSourceCode>
    {
        public override PSSourceCode Import(string filename, 
            ContentImporterContext context)
        {
            string sourceCode = System.IO.File.ReadAllText(filename);
            return new PSSourceCode(sourceCode, System.IO.Path.GetFileNameWithoutExtension(filename));
        }
    }
