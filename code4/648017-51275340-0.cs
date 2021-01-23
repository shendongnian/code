    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace NumericUpDownNullableProj
    {
        /// <summary>
        /// Represents a Windows spin box (also known as an up-down control) that displays numeric values.
        /// </summary>
        [ClassInterface(ClassInterfaceType.AutoDispatch)]
        [ComVisible(true)]
        [DefaultBindingProperty("Value")]
        [DefaultEvent("ValueChanged")]
        [DefaultProperty("Value")]
        //[SRDescriptionAttribute("DescriptionNumericUpDown")]
        public class NumericUpDownNullable : NumericUpDown
        {
            public NumericUpDownNullable() : base()
            {
                Text = "";
    
                ValueChanged += NumericUpDownNullable_ValueChanged;
                TextChanged += NumericUpDownNullable_TextChanged;
            }
    
            public NumericUpDownNullable(IContainer container) : this()
            {
                container.Add(this);
            }
    
            private void NumericUpDownNullable_TextChanged(object sender, EventArgs e)
            {
                if (Text == "")
                {
                    Value = null;
                }
            }
    
            private void NumericUpDownNullable_ValueChanged(object sender, EventArgs e)
            {
                if (Value != base.Value)
                {
                    Value = base.Value;
                }
            }
    
            private decimal? _value;
            /// <summary>
            /// Gets or sets the value assigned to the spin box (also known as an up-down control).
            /// 
            /// Returns:
            ///      The numeric value of the System.Windows.Forms.NumericUpDown control.
            /// Exceptions:
            ///    T:System.ArgumentOutOfRangeException:
            ///       The assigned value is less than the System.Windows.Forms.NumericUpDown.Minimum
            ///       property value.-or- The assigned value is greater than the System.Windows.Forms.NumericUpDown.Maximum property value.
            /// </summary>
            [Bindable(true)]
            public new decimal? Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
    
                    if (base.Value != value.GetValueOrDefault())
                    {
                        base.Value = value.GetValueOrDefault();
                    }
    
                    Text = value?.ToString();
                }
            }
        }
    }
