    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace RedoUndoApp
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string[] RTBRedoUndo;
        public int StackCount = 0;
        public int OldLength = 0;
        public int ChangeToSave = 5;
        public bool IsRedoUndo = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            RTBRedoUndo = new string[10000];
            RTBRedoUndo[0] = "";
        }
        private void undo_Click(object sender, EventArgs e)
        {
            IsRedoUndo = true;
            if (StackCount > 0 && RTBRedoUndo[StackCount - 1] != null)
            {
                StackCount = StackCount - 1;
                richTextBox1.Text = RTBRedoUndo[StackCount];
            }
        }
        private void redo_Click(object sender, EventArgs e)
        {
            IsRedoUndo = true;
            if (StackCount > 0 && RTBRedoUndo[StackCount + 1] != null)
            {
                StackCount = StackCount + 1;
                richTextBox1.Text = RTBRedoUndo[StackCount];
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (IsRedoUndo == false && richTextBox1.Text.Substring(richTextBox1.Text.Length - 1, 1) == " ")//(Math.Abs(richTextBox1.Text.Length - OldLength) >= ChangeToSave && IsRedoUndo == false)
            {
                StackCount = StackCount + 1;
                RTBRedoUndo[StackCount] = richTextBox1.Text;
                OldLength = richTextBox1.Text.Length;
            }
        }
        private void undo_MouseUp(object sender, MouseEventArgs e)
        {
            IsRedoUndo = false;
        }
        private void redo_MouseUp(object sender, MouseEventArgs e)
        {
            IsRedoUndo = false;
        }
    }
    }
