    namespace WindowsFormsApplication5
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        using System.Drawing.Drawing2D;
        /// <summary>
        /// Main application form
        /// </summary>
        public partial class Form1 : Form
        {
            /// <summary>
            /// Initializes a new instance of the WindowsFormsApplication5.Form1 class
            /// </summary>
            public Form1() {
                InitializeComponent();
                DoubleBuffered = true;
            }
            private Point selectionStart;
            private Point selectionEnd;
            private Rectangle selection;
            private bool mouseDown;
            private void GetSelectedTextBoxes() {
                List<TextBox> selected = new List<TextBox>();
                foreach (Control c in Controls) {
                    if (c is TextBox) {
                        if (selection.IntersectsWith(c.Bounds)) {
                            selected.Add((TextBox)c);
                        }
                    }
                }
                // Replace with your input box
                MessageBox.Show("You selected " + selected.Count + " textbox controls.");
            }
            protected override void OnMouseDown(MouseEventArgs e) {
                selectionStart = PointToClient(MousePosition);
                mouseDown = true;
            }
            protected override void OnMouseUp(MouseEventArgs e) {
                mouseDown = false;
                SetSelectionRect();
                Invalidate();
                GetSelectedTextBoxes();
            }
            protected override void OnMouseMove(MouseEventArgs e) {
                if (!mouseDown) {
                    return;
                }
                selectionEnd = PointToClient(MousePosition);
                SetSelectionRect();
                Invalidate();
            }
            protected override void OnPaint(PaintEventArgs e) {
                base.OnPaint(e);
                if (mouseDown) {
                    using (Pen pen = new Pen(Color.Black, 1F)) {
                        pen.DashStyle = DashStyle.Dash;
                        e.Graphics.DrawRectangle(pen, selection);
                    }
                }
            }
            private void SetSelectionRect() {
                int x, y;
                int width, height;
                x = selectionStart.X > selectionEnd.X ? selectionEnd.X : selectionStart.X;
                y = selectionStart.Y > selectionEnd.Y ? selectionEnd.Y : selectionStart.Y;
                width = selectionStart.X > selectionEnd.X ? selectionStart.X - selectionEnd.X : selectionEnd.X - selectionStart.X;
                height = selectionStart.Y > selectionEnd.Y ? selectionStart.Y - selectionEnd.Y : selectionEnd.Y - selectionStart.Y;
                selection = new Rectangle(x, y, width, height);
            }
        }
    }
