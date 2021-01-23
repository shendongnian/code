    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ComboBoxWrapperSample
    {
    
        /// <summary>
        /// Wrapper that adds supports to null values upon ComboBox.ItemsSource
        /// </summary>
        /// <typeparam name="T">Source combobox items collection datatype</typeparam>
        public class ComboBoxNullableItemWrapper<T>
        {
            string _nullValueText;
    
            private T _value;
    
            public T Value
            {
                get { return _value; }
                set { _value = value; }
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Value">Source object</param>
            /// <param name="NullValueText">Text to be presented whenever Value argument object is NULL</param>
            public ComboBoxNullableItemWrapper(T Value, string NullValueText = "(none)")
            {
                this._value = Value;
                this._nullValueText = NullValueText;
            }
    
            /// <summary>
            /// Text that will be shown on combobox items
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                string result;
                if (this._value == null)
                    result = _nullValueText;
                else
                    result = _value.ToString();
                return result;
            }
    
        }
    }
