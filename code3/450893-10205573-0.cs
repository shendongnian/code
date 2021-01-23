      using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Data;
        using System.Windows.Documents;
        using System.Windows.Input;
        using System.Windows.Media;
        using System.Windows.Media.Imaging;
        using System.Windows.Navigation;
        using System.Windows.Shapes;
        using Steema.TeeChart.WPF;
        using Steema.TeeChart.WPF.Styles;
        using System.IO;
        using System.Windows.Markup;
        using Steema.TeeChart.WPF.Tools;
        using Steema.TeeChart.WPF.Drawing;
        using Steema.TeeChart.WPF.Themes;
        namespace WpfApplication1
        {
            public partial class MainWindow : Window
            {
                private Steema.TeeChart.WPF.Styles.Line series;
                private ScrollPager tool;
                BlackIsBackTheme black; 
        
                public MainWindow()
                {
                    InitializeComponent();
        
                    series = new Steema.TeeChart.WPF.Styles.Line();
                    tChart1.Series.Add(series);
                    tChart1.Chart.Aspect.View3D = false;
                    tChart1.Header.Visible = false;
                    tChart1.Legend.Visible = false;
        
                    series.FillSampleValues(500);
        
                    black = new BlackIsBackTheme(tChart1.Chart);
                    black.Apply();
        
        
                    tool = new ScrollPager(tChart1.Chart);
        
                    tool.Series = series;
                    black = new BlackIsBackTheme(tool.SubChartTChart.Chart);
                    black.Apply();
        
                    tool.SubChartTChart.Panel.Pen.Visible = false;
                    tool.SubChartTChart.Panel.Bevel.Inner = BevelStyles.None;
                    tool.SubChartTChart.Panel.Bevel.Outer = BevelStyles.None;
                }
    }
    }
