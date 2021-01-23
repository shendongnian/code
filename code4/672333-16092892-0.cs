    public class BetterComboBox : ComboBox 
    {
        private int _windows7CorrectedSelectedIndex = -1;
        private int? _selectedIndexWhenDroppedDown = null; 
        protected override void OnDropDown(EventArgs e)
        {  
            _selectedIndexWhenDroppedDown = SelectedIndex;    
            base.OnDropDown(e);
        }
            
        private bool _onDropDownClosedProcessing = false; 
        protected override void OnDropDownClosed(EventArgs e) 
        { 
            if (_selectedIndexWhenDroppedDown != null && _selectedIndexWhenDroppedDown != SelectedIndex)   
            {    
                try   
                {      
                    _onDropDownClosedProcessing = true;     
                    OnSelectionChangeCommitted(e);   
                }    
                finally   
                { 
                    _onDropDownClosedProcessing = false;   
                }   
            }   
            base.OnDropDownClosed(e);   
            if (SelectedIndex != _windows7CorrectedSelectedIndex)   
            {  
                SelectedIndex = _windows7CorrectedSelectedIndex;      
                OnSelectionChangeCommitted(e);  
            }
        } 
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {   
            if (!_onDropDownClosedProcessing)
                _windows7CorrectedSelectedIndex = SelectedIndex;    
            _selectedIndexWhenDroppedDown = null; 
            base.OnSelectionChangeCommitted(e); 
        } 
        protected override void OnSelectedIndexChanged(EventArgs e)
        {  
            bool alreadyMatched = true;   
            if (_windows7CorrectedSelectedIndex != SelectedIndex)  
            {  
                _windows7CorrectedSelectedIndex = SelectedIndex; 
                alreadyMatched = false; 
            }   
            base.OnSelectedIndexChanged(e);   
            //when not dropped down, the SelectionChangeCommitted event does not fire upon non-arrow keystrokes due (I suppose) to AutoComplete behavior   
            //this is not acceptable for my needs, and so I have come up with the best way to determine when to raise the event, without causing duplication of the event (alreadyMatched)   
            //and without causing the event to fire when programmatic changes cause SelectedIndexChanged to be raised (_processingKeyEventArgs implies user-caused)   
            if (!DroppedDown && !alreadyMatched && _processingKeyEventArgs)
                OnSelectionChangeCommitted(e); 
        } 
        private bool _processingKeyEventArgs = false;
        protected override bool ProcessKeyEventArgs(ref Message m)
        {  
            try   
            {   
                _processingKeyEventArgs = true; 
                return base.ProcessKeyEventArgs(ref m);  
            }  
            finally 
            { 
                _processingKeyEventArgs = false;  
            } 
        }
    } 
