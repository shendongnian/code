      sealed class NumericUpDownEmptyValueForbidder {
         internal NumericUpDownEmptyValueForbidder(NumericUpDown numericUpDown) {
            Debug.Assert(numericUpDown != null);
            m_NumericUpDown = numericUpDown;
            m_NumericUpDown.MouseUp += delegate { Update(); };
            m_NumericUpDown.KeyUp += delegate { Update(); };
            m_NumericUpDown.ValueChanged += delegate { Update(); };
            m_NumericUpDown.Enter += delegate { Update(); };
         }
         readonly NumericUpDown m_NumericUpDown;
         string m_LastKnownValueText;
         internal void Update() {
            var text = m_NumericUpDown.Text;
            if (text.Length == 0) {
               if (!string.IsNullOrEmpty(m_LastKnownValueText)) {
                  m_NumericUpDown.Text = m_LastKnownValueText;
               }
               return;
            }
            Debug.Assert(text.Length > 0);
            m_LastKnownValueText = text;
         }
      }
