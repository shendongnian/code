    public class ManifestProcessor : ContentProcessor<ContentManifestAsset, ContentManifestContent>
    {
        private static bool InProgress = false;
    
        public override ContentManifestContent Process(ContentManifestAsset input, ContentProcessorContext context)
        {
            if(InProgress) throw new InProgressBuildException();
            
            InProgress = true;
            
            return Build(input, context);
        }
        
        private static ContentManifestContent Build(ContentManifestAsset input, ContentProcessorContext context)
        {
            ContentManifestContent content;
            // build steps for Manifest/Assets/Recursion
            InProgress = false;
            
            return content;
        }
    }
