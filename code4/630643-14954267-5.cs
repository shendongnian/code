    public class ChainedElementInserter
    {
        OpenXmlElement _element;
        Worksheet _worksheet;
        bool _previousResult;
        
        // ctor that initializes all three fields goes here.
    
        public ChainedElementInserter Or<T>()
            where T : OpenXmlElement
        {
            if (!_previousResult)
                _previousResult = _worksheet.InsertElementAfter<T>(_element);
            
            return this;
        }
    }
