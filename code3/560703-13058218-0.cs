    public class ControlValues{
        
        private int_dropDownIndex;
        public int DropDownIndex{
             get { return _dropDownIndex; }
             set { _dropDownIndex= value; }
        }
        
        private string _textBoxValue;
        public string TextBoxValue{
             get { return _textBoxValue; }
             set { _textBoxValue= value; }
        }
    
        public ControlValues(int dropDownIndex, string textBoxValue){
             this._dropDownIndex = dropDownIndex;
             this._textBoxValue = textBoxValue;
        }
    }
