    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Diagnostics;
    namespace DrawLines
    {
        public class MainForm : Form
        {
            #region constants and readonly attributes
            private const int CELL_SIZE = 4; // width and height of each "cell" in the bitmap.
            private readonly Bitmap _myBitmap; // to draw on (displayed in picBox1).
            private readonly Graphics _myGraphics; // to draw with.
            // actual points on _theLineString are painted red.
            private static readonly SolidBrush _thePointBrush = new SolidBrush(Color.Red);
            // ... and are labeled in /*Bold*/ Black, 16 point Courier New
            private static readonly SolidBrush _theLabelBrush = new SolidBrush(Color.Black);
            private static readonly Font _theLabelFont = new Font("Courier New", 16); //, FontStyle.Bold);
            // the interveening calculated cells on the lines between actaul points are painted Silver.
            private static readonly SolidBrush _theLineBrush = new SolidBrush(Color.Silver);
            // the points in my line-string.
            private static readonly Point[] _thePoints = new Point[] {
                //          x,   y      c i
                new Point(170,  85), // A 0 
                new Point( 85,  70), // B 1
                new Point(209,  66), // C 2
                new Point( 98, 120), // D 3
                new Point(158,  19), // E 4
                new Point(  2,  61), // F 5
                new Point( 42, 177), // G 6
                new Point(191, 146), // H 7
                new Point( 25, 128), // I 8
                new Point( 95,  24)  // J 9
            };
            #endregion
            public MainForm() {
                InitializeComponent();
                // initialise "the graphics system".
                _myBitmap = new Bitmap(picBox1.Width, picBox1.Height);
                _myGraphics = Graphics.FromImage(_myBitmap);
                picBox1.Image = _myBitmap;
            }
            #region DrawPoints upon MainForm_Load
            private void MainForm_Load(object sender, EventArgs e) {
                DrawPoints();
            }
            // draws and labels each point in _theLineString
            private void DrawPoints() {
                char c = 'A'; // label text, as a char so we can increment it for each point.
                foreach ( Point p in _thePoints ) {
                    DrawCell(p.X, p.Y, _thePointBrush);
                    DrawLabel(p.X, p.Y, c++);
                }
            }
            #endregion
            #region DrawLines on button click
            // =====================================================================
            // Here's the interesting bit. DrawLine was called Draw
            // Draws a line from A to B, by using X-values to calculate the Y values.
            private void DrawLine(Point a, Point b)
            {
                if ( a.Y > b.Y ) // A is below B
                    Swap(ref a, ref b); // make A the topmost point (ergo sort by Y)
                Debug.Assert(a.Y < b.Y, "A is still below B!");
                var left = Math.Min(a.X, b.X);
                var right = Math.Max(a.X, b.X);
                int width = right - left;
                Debug.Assert(width >= 0, "width is negative!");
                var top = a.Y;
                var bottom = b.Y;
                int height = bottom - top;
                Debug.Assert(height >= 0, "height is negative!");
                if ( width > height ) {
                    // use given X values to calculate the Y values, 
                    // otherwise it "skips" some X's
                    double slope = (double)height / (double)width; 
                    Debug.Assert(slope >= 0, "slope is negative!");
                    if (a.X <= b.X)     // a is left-of b, so draw left-to-right.
                        for ( int x=1; x<width; ++x ) // xOffset
                            DrawCell( (left+x), (a.Y + ((int)(slope*x + 0.5))), _theLineBrush);
                    else                // a is right-of b, so draw right-to-left.
                        for ( int x=1; x<width; ++x ) // xOffset
                            DrawCell( (right-x), (a.Y + ((int)(slope*x + 0.5))), _theLineBrush);
                } else {
                    // use given Y values to calculate the X values, 
                    // otherwise it "skips" some Y's
                    double slope = (double)width/ (double)height; 
                    Debug.Assert(slope >= 0, "slope is negative!");
                    if (a.X <= b.X) {     // a is left-of b, so draw left-to-right. (FG)
                        for ( int y=1; y<height; ++y ) // yOffset
                            DrawCell( (a.X + ((int)(slope*y + 0.5))), (top+y), _theLineBrush);
                    } else {              // a is right-of b, so draw right-to-left. (DE,IJ)
                        for ( int y=1; y<height; ++y ) // yOffset
                            DrawCell( (b.X + ((int)(slope*y + 0.5))), (bottom-y), _theLineBrush);
                    }
                }
            }
            private void btnDrawLines_Click(object sender, EventArgs e) {
                DrawLines();  // join the points
                DrawPoints(); // redraw the labels over the lines.
            }
            // Draws a line between each point in _theLineString.
            private void DrawLines() {
                int n = _thePoints.Length - 1; // one less line-segment than points
                for ( int i=0; i<n; ++i )
                    DrawLine(_thePoints[i], _thePoints[i+1]);
                picBox1.Invalidate(); // tell the graphics system that the picture box needs to be repainted.
            }
            private void Swap(ref Point a, ref Point b) {
                Point tmp = a;
                a = b;
                b = tmp;
            }
            #endregion
            #region actual drawing on _myGraphics
            // there should be no calls to Draw or Fill outside of this region
            private void DrawCell(int x, int y, Brush brush) {
                _myGraphics.FillRectangle(
                    brush
                  , x*CELL_SIZE
                  , y*CELL_SIZE 
                  , CELL_SIZE   // width
                  , CELL_SIZE   // heigth
                );
            }
            private void DrawLabel(int x, int y, char c) {
                string s = c.ToString();
                _myGraphics.DrawString(
                    s, _theLabelFont, _theLabelBrush
                  , x * CELL_SIZE + 5   // x
                  , y * CELL_SIZE - 10  // y
                );
            }
            #endregion
            #region Windows Form Designer generated code
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent() {
                this.picBox1 = new System.Windows.Forms.PictureBox();
                this.btnDrawLines = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // picBox1
                // 
                this.picBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.picBox1.Location = new System.Drawing.Point(0, 0);
                this.picBox1.Name = "picBox1";
                this.picBox1.Size = new System.Drawing.Size(1000, 719);
                this.picBox1.TabIndex = 0;
                this.picBox1.TabStop = false;
                // 
                // btnDrawLines
                // 
                this.btnDrawLines.Location = new System.Drawing.Point(23, 24);
                this.btnDrawLines.Name = "btnDrawLines";
                this.btnDrawLines.Size = new System.Drawing.Size(77, 23);
                this.btnDrawLines.TabIndex = 1;
                this.btnDrawLines.Text = "Draw Lines";
                this.btnDrawLines.UseVisualStyleBackColor = true;
                this.btnDrawLines.Click += new System.EventHandler(this.btnDrawLines_Click);
                // 
                // MainForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(1000, 719);
                this.Controls.Add(this.btnDrawLines);
                this.Controls.Add(this.picBox1);
                this.Location = new System.Drawing.Point(10, 10);
                this.MinimumSize = new System.Drawing.Size(1016, 755);
                this.Name = "MainForm";
                this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "Draw Lines on a Matrix.";
                this.Load += new System.EventHandler(this.MainForm_Load);
                ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
                this.ResumeLayout(false);
            }
            private System.Windows.Forms.PictureBox picBox1;
            private System.Windows.Forms.Button btnDrawLines;
            #endregion
        }
    }
