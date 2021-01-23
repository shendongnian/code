    using System;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace RotatingMatrices
    {
        public partial class Form1 : Form
        {
            public Form1 ( )
            {
                InitializeComponent();
    
                string[,] unrotated =
                    {{"11", "12", "13", "14", "15"},
                     {"21", "22", "23", "24", "25"},
                     {"31", "32", "33", "34", "35"},
                     {"41", "42", "43", "44", "45"},
                     {"51", "52", "53", "54", "55"}};
    
                Debug.WriteLine("original matrix:");
                RotateMatrix.DebugPrintMatrix(unrotated);
    
                string[,] rotated = RotateMatrix.RotateClockwiseSkipDiagonals(unrotated);
    
                Debug.WriteLine("");
                Debug.WriteLine("matrix rotated once:");
                RotateMatrix.DebugPrintMatrix(rotated);
    
                rotated = RotateMatrix.RotateClockwiseSkipDiagonals(rotated);
    
                Debug.WriteLine("");
                Debug.WriteLine("matrix rotated twice:");
                RotateMatrix.DebugPrintMatrix(rotated);
    
                rotated = RotateMatrix.RotateClockwiseSkipDiagonals(rotated);
                rotated = RotateMatrix.RotateClockwiseSkipDiagonals(rotated);
    
                Debug.WriteLine("");
                Debug.WriteLine("matrix rotated four times:");
                RotateMatrix.DebugPrintMatrix(rotated);
            }
        }
    }
