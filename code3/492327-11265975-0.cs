        List<object> calculatorChain = new List<object>();
        /// <summary>
        /// Handles the button press for the minus key
        /// </summary>
        /// <param name="sender">The originating object</param>
        /// <param name="e">Event arguments</param>
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            CommitOperand(textBox1.Text, "-");
            textBox1.Text = string.Empty;
        }
        /// <summary>
        /// Commits the current working number to the calculator chain with a given operator
        /// </summary>
        /// <param name="operand">The current working number to add</param>
        /// <param name="operation">The operation to perform</param>
        private void CommitOperand(string operand, string operation)
        {
            if (string.IsNullOrWhiteSpace(operand) || string.IsNullOrWhiteSpace(operation))
            {
                return;
            }
            else
            {
                decimal number;
                if (decimal.TryParse(operand, out number))
                {
                    calculatorChain.Add(number);
                    calculatorChain.Add(operation);
                }
            }
        }
