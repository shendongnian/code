    public class ManifestProcessor : ContentProcessor<ContentManifestAsset, ContentManifestContent>
    {
        private static readonly Dictionary<string, ContentManifestContent> BuildCache = new Dictionary<string, ContentManifestContent>();
    
        public override ContentManifestContent Process(ContentManifestAsset input, ContentProcessorContext context)
        {
            ContentManifestContent content;
            
            if(!BuildCache.TryGetValue(input.Name, out content))
            {
                VerifyStackIntegrity(context, input.Name);
                content = Build(input, context);
                BuildCache.Add(input.Name, content);
                context.BuildStack.Pop();
            }
            
            return content;
        }
        
        private static void VerifyStackIntegrity(ContentProcessorContext context, string buildStep)
        {
            if(context.BuildStack.Count(x => x == buildStep) > 1)
                throw new CircularBuildException();
                
            context.BuildStack.Push(buildStep);
        }
        
        private static ContentManifestContent Build(ContentManifestAsset input, ContentProcessorContext context)
        {
            // build steps for Manifest/Assets/Recursion
        }
    }
