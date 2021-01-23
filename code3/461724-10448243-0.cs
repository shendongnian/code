    namespace Wiggle.CategoryXMLExporter.IEntities
    {
        public interface IRange
        {
            long ID { get; }
            Dictionary<ILanguage, string> rangeNames { get; set; }
        }
    }
