    <Window x:Class="WpfInkCavasSaveImage.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow"  Height="1091" Width="873" WindowState="Maximized">
        <Grid Margin="0,0,0,173" >
            <Grid.RowDefinitions>
                <RowDefinition Height="1200*" />
                <RowDefinition Height="50" />
            </Grid.RowDefinitions>    
            <InkCanvas HorizontalAlignment="Stretch" Margin="1,1,1,10" x:Name="inkCanvas1" VerticalAlignment="Stretch" Width="Auto" RenderTransformOrigin="0.5,0.5" Background="LightGreen" SnapsToDevicePixels="True" IsManipulationEnabled ="True"  Grid.RowSpan="2">
                <InkCanvas.CacheMode>
                    <BitmapCache/>
                </InkCanvas.CacheMode>
                <InkCanvas.DefaultDrawingAttributes>
                    <DrawingAttributes Color="Black" FitToCurve="True" Height="2.0031496062992127" IgnorePressure="False" IsHighlighter="False" StylusTip="Ellipse" StylusTipTransform="Identity" Width="2.0031496062992127"/>    
                </InkCanvas.DefaultDrawingAttributes>
            </InkCanvas>
            <Button x:Name="btnSaveImage" Content="Save Ink Canvas" Height="41" Width="155" Canvas.Left="100" Canvas.Top="900"  VerticalAlignment="Top" HorizontalAlignment="Left" RenderTransformOrigin="1.417,14.6" Margin="15,93,0,-84" Background="SkyBlue" Click="btnSaveInkCanvas" Grid.Row="1" BorderBrush="{x:Null}"/>
        </Grid>
        
    </Window>
    
    
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfInkCavasSaveImage
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                inkCanvas1.Width = System.Windows.SystemParameters.WorkArea.Width;
                inkCanvas1.Height = System.Windows.SystemParameters.WorkArea.Height;
            }
            private void btnSaveInkCanvas(object sender, RoutedEventArgs e)
            {
                string subpath = Directory.GetCurrentDirectory();
                SaveFileDialog saveFileDialog12 = new SaveFileDialog();
                saveFileDialog12.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png File|*.png";
                saveFileDialog12.Title = "Save an Image File";
                saveFileDialog12.InitialDirectory = subpath;
                saveFileDialog12.ShowDialog();
    
                if (saveFileDialog12.FileName == "") return;
                subpath = saveFileDialog12.FileName.Substring(0, saveFileDialog12.FileName.Length - saveFileDialog12.SafeFileName.Length);
           
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkCanvas1.Width, (int)inkCanvas1.Height, 96d, 96d, PixelFormats.Default);
                rtb.Render(inkCanvas1);
                DrawingVisual dvInk = new DrawingVisual();
                DrawingContext dcInk = dvInk.RenderOpen();
                dcInk.DrawRectangle(inkCanvas1.Background, null, new Rect(0d, 0d, inkCanvas1.Width, inkCanvas1.Height));
                foreach (System.Windows.Ink.Stroke stroke in inkCanvas1.Strokes)
                {
                    stroke.Draw(dcInk);
                }
                dcInk.Close();
    
                FileStream fs = File.Open(saveFileDialog12.FileName, FileMode.OpenOrCreate);//save bitmap to file
                System.Windows.Media.Imaging.JpegBitmapEncoder encoder1 = new JpegBitmapEncoder();
                encoder1.Frames.Add(BitmapFrame.Create(rtb));
                encoder1.Save(fs);
                fs.Close();
            }
        }
    }
