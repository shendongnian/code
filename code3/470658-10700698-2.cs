    public class GeneralController : Controller
    {
        [Import]
        public ITranslator Translator { get; set; }
    
        public JsonResult Translate(string text)
        {
            var container = new CompositionContainer(
    		new DirectoryCatalog(Path.Combine(HttpRuntime.BinDirectory, "Plugins")));
            CompositionBatch compositionBatch = new CompositionBatch();
            compositionBatch.AddPart(this);
            Container.Compose(compositionBatch);
            
            return Json(new
            {
                source = text,
                translation = Translator.Translate(text)
            });
        }
    }
