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
    using System.IO;
    using System.Windows.Resources;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Uri uri = new Uri("pack://application:,,,/test.ico");
    
                Stream iconstream = GetCURFromICO(uri, 15, 15 );
    
                Cursor cursor = new Cursor(iconstream);
    
                this.Cursor = cursor;
            }
    
            public static Stream GetCursorFromICO(Uri uri, byte hotspotx, byte hotspoty)
            {
                StreamResourceInfo sri = Application.GetResourceStream(uri);
                Stream s = sri.Stream;
                byte []buffer = new byte[s.Length];
                s.Read(buffer, 0, (int)s.Length);
                MemoryStream ms = new MemoryStream();
                buffer[2] = 2; // change to CUR file type
                buffer[10] = hotspotx;
                buffer[12] = hotspoty;
                ms.Write(buffer, 0, (int)s.Length);
                ms.Position = 0;
                return ms;
            }
            public static Stream GetCURFromICOAlternativeMethod(Uri uri, byte hotspotx, byte hotspoty)
            {
                StreamResourceInfo sri = Application.GetResourceStream(uri);
    
                Stream s = sri.Stream;
    
                byte []buffer = new byte[s.Length];
    
                MemoryStream ms = new MemoryStream();
    
                ms.WriteByte(0); // always 0
                ms.WriteByte(0);
                ms.WriteByte(2); // change file type to CUR
                ms.WriteByte(0);
                ms.WriteByte(1); // 1 icon in table
                ms.WriteByte(0);
    
                s.Position = 6; // skip over first 6 bytes in ICO as we just wrote
    
                s.Read(buffer, 0, 4);
                ms.Write(buffer, 0, 4);
    
                ms.WriteByte(hotspotx);
                ms.WriteByte(0);
    
                ms.WriteByte(hotspoty);
                ms.WriteByte(0);
    
                s.Position += 4; // skip 4 bytes as we just wrote our own
    
                int remaining = (int)s.Length - 14;
    
                s.Read(buffer, 0, remaining);
                ms.Write(buffer, 0, remaining);
    
                ms.Position = 0;
    
                return ms;
            }
        }
    }
----------
    <Window x:Class="WpfApplication2.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            
        </Grid>
    </Window>
