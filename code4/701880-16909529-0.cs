    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace TextBoxes
    {
        public partial class Form1 : Form
        {
    
            List<TextBox[]> _textBoxes;
            public Form1()
            {
                InitializeComponent();
    
                this._textBoxes= new List<TextBox[]>();
                
                TextBox[] row1 = new TextBox[4];
                row1[0] = textBox1;
                row1[1] = textBox2;
                row1[2] = textBox3;
                row1[3] = textBox4;
    
                TextBox[] row2 = new TextBox[4];
                row2[0] = textBox5;
                row2[1] = textBox6;
                row2[2] = textBox7;
                row2[3] = textBox8;
    
                TextBox[] row3 = new TextBox[4];
                row3[0] = textBox9;
                row3[1] = textBox10;
                row3[2] = textBox11;
                row3[3] = textBox12;
    
                TextBox[] row4 = new TextBox[4];
                row4[0] = textBox13;
                row4[1] = textBox14;
                row4[2] = textBox15;
                row4[3] = textBox16;
    
                this._textBoxes.Add(row1);
                this._textBoxes.Add(row2);
                this._textBoxes.Add(row3);
                this._textBoxes.Add(row4);
                    
                   
                
            }
    
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                Control activeCtrl = this.ActiveControl;
                TextBox txb = activeCtrl as TextBox;
                if (txb != null)
                {
                    int row;
                    int column;
    
                    this.GetTextBoxIndexes(txb, out row, out column);
                    
                    if (keyData == Keys.Up)
                    {
                        row--;
                    }
                    else if (keyData == Keys.Down)
                    {
                        row++;
                    }
                    else if (keyData == Keys.Left)
                    {
                        column--;
                    }
                    else if (keyData == Keys.Right)
                    {
                        column++;
                    }
    
                    row = Math.Abs(row + 4) % 4;
                    column = Math.Abs(column + 4) % 4;
                   
    
                    TextBox slected = this._textBoxes[row][column];
                    slected.Focus();
                    
                }
                return base.ProcessCmdKey(ref msg, keyData);
                
               
            }
    
            /// <summary>
            /// Gets the text box indexes.
            /// </summary>
            /// <param name="txb">The texbox.</param>
            /// <param name="row">The out row index.</param>
            /// <param name="column">The out column index.</param>
            private void GetTextBoxIndexes(TextBox txb, out int row, out int column)
            {
                row = -1;
                column = -1;
                for (int rowIdx = 0; rowIdx < this._textBoxes.Count; rowIdx++)
                {
                    TextBox[] currRow = this._textBoxes[rowIdx];
                    for (int colIdx = 0; colIdx < currRow.Length; colIdx++)
                    {
                        TextBox currTextBox = this._textBoxes[rowIdx][colIdx];
                        if (currTextBox.Equals(txb))
                        {
                            row = rowIdx;
                            column = colIdx;
                            return;
                        }
                    }
                }
            }
        }
    }
