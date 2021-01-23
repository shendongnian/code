    using System;
    using System.Windows.Forms;
    
    namespace Calculator
    {
        public enum Operator
        {
            None,
            Add,
            Minus,
            Divide,
            Multiply
        }
    
        public partial class Calculator : Form
        {
            private double total = 0;
            private double currentValue = 0;
            private Operator currentOperator;
    
            public Calculator()
            {
                InitializeComponent();
            }
    
            private void btnOne_Click(object sender, EventArgs e)
            {
                ShowInput(btnOne.Text);
            }
    
            private void btnTwo_Click(object sender, EventArgs e)
            {
                ShowInput(btnTwo.Text);
            }
    
            private void btnThree_Click(object sender, EventArgs e)
            {
                ShowInput(btnThree.Text);
            }
    
            private void btnFour_Click(object sender, EventArgs e)
            {
                ShowInput(btnFour.Text);
            }
    
            private void btnFive_Click(object sender, EventArgs e)
            {
                ShowInput(btnFive.Text);
            }
    
            private void btnSix_Click(object sender, EventArgs e)
            {
                ShowInput(btnSix.Text);
            }
    
            private void btnSeven_Click(object sender, EventArgs e)
            {
                ShowInput(btnSeven.Text);
            }
    
            private void btnEight_Click(object sender, EventArgs e)
            {
                ShowInput(btnEight.Text);
            }
    
            private void btnNine_Click(object sender, EventArgs e)
            {
                ShowInput(btnNine.Text);
            }
    
            private void btnZero_Click(object sender, EventArgs e)
            {
                ShowInput(btnZero.Text);
            }
    
            private void btnClear_Click(object sender, EventArgs e)
            {
                currentOperator = Operator.None;
                txtDisplay.Clear();
                total = 0;
            }
    
            private void btnPoint_Click(object sender, EventArgs e)
            {
                txtDisplay.Text = txtDisplay.Text + '.';
            }
    
            private void btnPlus_Click(object sender, EventArgs e)
            {
                ApplyOperator(Operator.Add);
            }
    
            private void btnMinus_Click(object sender, EventArgs e)
            {
                ApplyOperator(Operator.Minus);
            }
    
            private void btnDivide_Click(object sender, EventArgs e)
            {
                ApplyOperator(Operator.Divide);
            }
    
            private void btnMultiply_Click(object sender, EventArgs e)
            {
                ApplyOperator(Operator.Multiply);
            }
    
            private void btnEquals_Click(object sender, EventArgs e)
            {
                Evaluate();
                txtDisplay.Text = Convert.ToString(total);
            }
    
            private void Evaluate()
            {
                switch (currentOperator)
                {
                    case Operator.Add:
                        total += currentValue;
                        break;
                    case Operator.Minus:
                        total -= currentValue;
                        break;
                    case Operator.Divide:
                        total /= currentValue;
                        break;
                    case Operator.Multiply:
                        total *= currentValue;
                        break;
                    case Operator.None:
                        break;
                }
                currentValue = 0;
                currentOperator = Operator.None;
            }
    
            private void ApplyOperator(Operator op)
            {
                if (currentOperator != Operator.None)
                {
                    Evaluate();
                }
                else
                {
                    total = double.Parse(txtDisplay.Text);
                }
                txtDisplay.Clear();
                currentOperator = op;
            }
    
            private void ShowInput(String n)
            {
                txtDisplay.Text = txtDisplay.Text + n;
                currentValue = double.Parse(txtDisplay.Text);
            }
        }
    }
