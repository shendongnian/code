    public class ChainedElementInserter
    {
        OpenXmlElement _element;
        Worksheet _worksheet;
        bool _previousResult;
        
        // ctor that initializes all three fields goes here.
    
        public ChainedElementInserter Or<T>()
            where T : OpenXmlElement
        {
            if(_previousResult)
                return this;
    
            return new ChainedElementInserter(
                _worksheet, _element, _worksheet.InsertElementAfter<T>(_element));
        }
    }
