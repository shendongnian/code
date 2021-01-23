    using System;
    using System.Windows.Forms;
    using GMap.NET.MapProviders;
    using GMap.NET;
    
    namespace gmap
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                //use google provider
                gMapControl1.MapProvider = GoogleMapProvider.Instance;
                //get tiles from server only
                gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //center map on moscow
                gMapControl1.Position = new PointLatLng(55.755786121111, 37.617633343333);
            }
        }
    }
