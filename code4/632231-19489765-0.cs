    private void button1_Click(object sender, EventArgs e)
        {            
            String result = "";
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Shapefile (*.shp)|*.shp|All files (*.*)|*.*";
            openfile.ShowDialog();
            String filePath = openfile.FileName.Replace(".shp", "").Replace(@"\", @"\\");
            String[] a = filePath.Split('\\');
            String shpName = a[a.Length-1];
            try
            {
                SQLiteConnection.CreateFile(openfile.FileName.Replace(".shp", "")+".sqlite");
                System.Data.SQLite.SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + openfile.FileName.Replace(".shp", "") + ".sqlite");
                    
               
                connection.Open();
                object returnvalue = new SQLiteCommand("SELECT load_extension('libspatialite-2.dll')", connection).ExecuteScalar();
                
                System.Data.SQLite.SQLiteCommand commande = new SQLiteCommand(connection);
                commande.CommandText = "CREATE virtual TABLE "+shpName+"VT USING VirtualShape('" + filePath + "', 'CP1252', 4326);";
     
                commande.ExecuteScalar();
               
                commande.CommandText = "CREATE TABLE geom AS SELECT * FROM " + shpName + "VT;";
                commande.ExecuteScalar();
                commande.CommandText = "drop table " + shpName + "VT";
                commande.ExecuteScalar();
           
                commande.CommandText = "ALTER TABLE geom ADD COLUMN WKT TEXT;";
                commande.ExecuteScalar();
               
                commande.CommandText = " UPDATE  geom set WKT= ST_AsText(Geometry);";
                commande.ExecuteScalar();
             
               // the test commande
                commande.CommandText = "SELECT WKT FROM geom;";
          
                result = (string)commande.ExecuteScalar();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(result);
        }
