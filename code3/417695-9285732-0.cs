        public class Location
        {
            public int X { set; get; }
            public int Y { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
              List<Location> locations1 = new List<Location>()
                {
                    new Location(){X= 100, Y = 200},
                    new Location(){X= 300, Y = 400},
                    new Location(){X= 600, Y = 500},
                    new Location(){X= 700, Y = 800}    
                };
              dataGridView1.DataSource = locations1;
        }
