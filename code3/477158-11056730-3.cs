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
    using System.Windows.Media.Media3D;
    using Microsoft.Kinect;
    namespace PointCloudWPF
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GeometryModel3D[] points = new GeometryModel3D[320 * 240];
        int s = 4;
        KinectSensor sensor;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        void DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            DepthImageFrame imageFrame = e.OpenDepthImageFrame();
            if (imageFrame != null)
            {
                short[] pixelData = new short[imageFrame.PixelDataLength];
                imageFrame.CopyPixelDataTo(pixelData);
                int temp = 0;
                int i = 0;
                for (int y = 0; y < 240; y += s)
                    for (int x = 0; x < 320; x += s)
                    {
                        temp = ((ushort)pixelData[x + y * 320]) >> 3;
                        ((TranslateTransform3D)points[i].Transform).OffsetZ = temp;
                        i++;
                    }
            }
        }
        private GeometryModel3D Triangle(double x, double y, double s, SolidColorBrush color)
        {
            Point3DCollection corners = new Point3DCollection();
            corners.Add(new Point3D(x, y, 0));
            corners.Add(new Point3D(x, y + s, 0));
            corners.Add(new Point3D(x + s, y + s, 0));
            Int32Collection Triangles = new Int32Collection();
            Triangles.Add(0);
            Triangles.Add(1);
            Triangles.Add(2);
            MeshGeometry3D tmesh = new MeshGeometry3D();
            tmesh.Positions = corners;
            tmesh.TriangleIndices = Triangles;
            tmesh.Normals.Add(new Vector3D(0, 0, -1));
            GeometryModel3D msheet = new GeometryModel3D();
            msheet.Geometry = tmesh;
            msheet.Material = new DiffuseMaterial(color);
            return msheet;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DirectionalLight DirLight1 = new DirectionalLight();
            DirLight1.Color = Colors.White;
            DirLight1.Direction = new Vector3D(1, 1, 1);
            PerspectiveCamera Camera1 = new PerspectiveCamera();
            Camera1.FarPlaneDistance = 8000;
            Camera1.NearPlaneDistance = 100;
            Camera1.FieldOfView = 10;
            Camera1.Position = new Point3D(160, 120, -1000);
            Camera1.LookDirection = new Vector3D(0, 0, 1);
            Camera1.UpDirection = new Vector3D(0, -1, 0);
            Model3DGroup modelGroup = new Model3DGroup();
            int i = 0;
            for (int y = 0; y < 240; y += s)
            {
                for (int x = 0; x < 320; x += s)
                {
                    points[i] = Triangle(x, y, s, new SolidColorBrush(Colors.White));
                    // points[i]=MCube(x,y);
                    points[i].Transform = new TranslateTransform3D(0, 0, 0);
                    modelGroup.Children.Add(points[i]);
                    i++;
                }
            }
            modelGroup.Children.Add(DirLight1);
            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;
            Viewport3D myViewport = new Viewport3D();
            myViewport.IsHitTestVisible = false;
            myViewport.Camera = Camera1;
            myViewport.Children.Add(modelsVisual);
            canvas1.Children.Add(myViewport);
            myViewport.Height = canvas1.Height;
            myViewport.Width = canvas1.Width;
            Canvas.SetTop(myViewport, 0);
            Canvas.SetLeft(myViewport, 0);
            sensor = KinectSensor.KinectSensors[0];
            sensor.SkeletonStream.Enable();
            sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
            sensor.DepthFrameReady += DepthFrameReady;
            sensor.Start();
        }
    }
    }
