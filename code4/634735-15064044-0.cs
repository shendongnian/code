    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using ZedGraph;
    
    namespace GraphTest
    {
        public partial class Form1 : Form
        {
            private readonly Fill _flip = new Fill(Color.White);
            private readonly PointPairList _mPointsListSample;
            private readonly GraphPane _myPane;
    
            public Form1()
            {
                InitializeComponent();
    
                _myPane = zedGraphControl1.GraphPane;
                _myPane.YAxis.Title.Text = "Sample";          
                _myPane.YAxis.Title.FontSpec.Size = 5f;
                _myPane.YAxis.Scale.FontSpec.Size = 5f;
                _myPane.XAxis.Scale.FontSpec.Size = 5f;
                _mPointsListSample = new PointPairList();
               
                _myPane.Chart.Fill = new Fill(Color.Black, Color.Black, 45F);
                _myPane.Fill = new Fill(Color.White, Color.Black, 45F);
    
                _myPane.XAxis.MajorGrid.IsVisible = true;
                _myPane.XAxis.Scale.Min = 0;
                _myPane.XAxis.Scale.Max = 10;
    
    
                _myPane.YAxis.Title.FontSpec.FontColor = Color.Pink;
                _myPane.YAxis.Scale.Align = AlignP.Inside;
                _myPane.YAxis.Scale.Min = 0;
                _myPane.YAxis.Scale.Max = 500;
    
    
              
            }
    
            private void Form1_Shown(object sender, EventArgs e)
            {
                var limit = new Random();
                bool flag = true;
                while (true)
                {
                    if (flag)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            _mPointsListSample.Add(i, limit.Next(500));
                            Thread.Sleep(500);
                            Application.DoEvents();
                            DrawGraph();
                            flag = false;
                        }
                    }
                    if (!flag)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            _mPointsListSample[i].Y = _mPointsListSample[i + 1].Y;
                        }
                        _mPointsListSample.Insert(9, 9, limit.Next(500));
                        _mPointsListSample.RemoveAt(10);
                        Thread.Sleep(500);
                        Application.DoEvents();
                        DrawGraph();
                    }
                }
            }
    
            private void DrawGraph()
            {
                _myPane.CurveList.Clear();
                // Fabricate some data values 
                LineItem myCurve = _myPane.AddCurve("Sample", _mPointsListSample, Color.Red, SymbolType.None);
                myCurve.Symbol.Fill = _flip;
                myCurve.Line.IsSmooth = true;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();
            }
        }
    }
