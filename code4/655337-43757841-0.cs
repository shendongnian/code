            if (_SourceText.Length < _MaxRowLength)
            {
                return _SourceText;
            }
            else 
            {
                string _RowBreakText="";
                int _CurrentPlace = 0;
                while (_CurrentPlace < _SourceText.Length)
                {
                    if (_SourceText.Length - _CurrentPlace < _MaxRowLength)
                    {
                        _RowBreakText += _SourceText.Substring(_CurrentPlace);
                        _CurrentPlace = _SourceText.Length; 
                    }
                    else
                    {
                        string _PartString = _SourceText.Substring(_CurrentPlace, _MaxRowLength);
                        int _LastSpace = _PartString.LastIndexOf(" ");
                        if (_LastSpace > 0)
                        {
                            _RowBreakText += _PartString.Substring(0, _LastSpace) + "<br/>" + _PartString.Substring(_LastSpace, (_PartString.Length - _LastSpace));
                        }
                        else
                        {
                            _RowBreakText += _PartString + "<br/>";
                        }
                        _CurrentPlace += _MaxRowLength;
                    }
                    
                }
                return _RowBreakText;
            
            }
        
        
        
        
        
