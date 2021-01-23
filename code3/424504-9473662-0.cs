      private void comboBox1_KeyDown(object sender, KeyEventArgs e)
      {
           BeginInvoke(new MethodInvoker(_CheckCaretPosition));
      }
    
      void _CheckCaretPosition()
      {
           int caretPosition = comboBox1.SelectionStart;
           Debug.WriteLine(caretPosition);
      }
