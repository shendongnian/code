        public class HTMLWorkerExtended : HTMLWorker
        {
        public HTMLWorkerExtended(IDocListener document): base(document)
        {
        }
        public override void StartElement(string tag, IDictionary<string, string> str)
        {
            if (tag.Equals("newpage"))
                document.Add(Chunk.NEXTPAGE);
            else
                base.StartElement(tag, str);
        }
        }
 
