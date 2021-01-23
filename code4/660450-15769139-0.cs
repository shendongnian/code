    class FieldBooleanSV : Field
    class FieldStringSV : Field
    class FieldInt32SV : Field
    public class FieldInt16SV : DocField
    {
        Int16 fieldValue;
        Int16 FieldValue { get { return fieldValue; }
            set
            {
                    if (value != fieldValue)
                    {
                        fieldValue = value;
                        NotifyPropertyChanged("DispValue");
                        NotifyPropertyChanged("FieldValue");
                    }
                }
            }
        }
        public override String DispValue 
        { 
            get 
            {  return fieldValue.ToString()); }
        }
    }
