    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Example.CustomControl
    {
        /// <summary>
        /// Provides an extra event for the numericUpDown control that fires after the value stops scrolling.
        /// </summary>
        public class NumericDelayedChange : NumericUpDown
        {
            /// <summary>
            /// Flag that the value has actually changed.
            /// </summary>
            /// <devdoc>
            /// Just in case the control was clicked somewhere other than the up/down buttons.
            /// </devdoc>
            private bool valueHasChanged = false;
    
            /// <summary>
            /// Fires when the value has stopped being scrolled.
            /// </summary>
            public event EventHandler OnAfterScollValueChanged;
    
            /// <summary>
            /// Captures that value as having changed.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnValueChanged(EventArgs e)
            {
                valueHasChanged = true;
                base.OnValueChanged(e);
            }
    
            /// <summary>
            /// Captures the mouse up event to identify scrolling stopped when used in combination with the value changed flag.
            /// </summary>
            /// <param name="mevent"></param>
            protected override void OnMouseUp(MouseEventArgs mevent)
            {
                base.OnMouseUp(mevent);
                if (mevent.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    PerformOnAfterScollValueChanged();
                }
            }
    
            /// <summary>
            /// Captures the key up/down events to identify scrolling stopped when used in combination with the value changed flag.
            /// </summary>
            /// <param name="mevent"></param>
            protected override void OnKeyUp(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    PerformOnAfterScollValueChanged();
                }
                base.OnKeyUp(e);
            }
    
            /// <summary>
            /// Checks the value changed flag and fires the OnAfterScollValueChanged event.
            /// </summary>
            private void PerformOnAfterScollValueChanged()
            {
                if (valueHasChanged)
                {
                    valueHasChanged = false;
                    if (OnAfterScollValueChanged != null) { OnAfterScollValueChanged(this, new EventArgs()); }
                }
            }
        }
    }
