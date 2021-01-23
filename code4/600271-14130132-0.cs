    /// <summary>
    /// Our custom HTML Tag to add an IElement.
    /// </summary>
    public class ResourceImageHtmlTagProcessor : AbstractTagProcessor
    {
        public override IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent)
        {
            var src = tag.Attributes["src"];
            var bitmap = (Bitmap)Resources.ResourceManager.GetObject(src);
            if (bitmap == null)
                throw new RuntimeWorkerException("No resource with the name: " + src);
            var converter = new ImageConverter();
            var image = Image.GetInstance((byte[])converter.ConvertTo(bitmap, typeof(byte[])));
            HtmlPipelineContext htmlPipelineContext = this.GetHtmlPipelineContext(ctx);
            return new List<IElement>(1)
                {
                    this.GetCssAppliers().Apply(
                        new Chunk((Image)this.GetCssAppliers().Apply(image, tag, htmlPipelineContext), 0f, 0f, true),
                        tag,
                        htmlPipelineContext)
                };
        }
    }
