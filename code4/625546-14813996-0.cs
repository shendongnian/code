    int result = new DataLayerHelper().RunQuery();
    MessageBox.Show(result.ToString());
[...]
    public class DataLayerHelper
    {
        public DataLayerHelper() { }
        public int RunQuery()
        {
            int forcatime;
            string comandomedia = "select avg(forca_jogador) from jogadores where nome_time = " + time;
            ocon.ConnectionString = con;
            MySqlCommand media = new MySqlCommand(comandomedia, ocon);
            ocon.Open();//consider a using statement
            forcatime = Convert.ToInt32(media.ExecuteScalar());
            ocon.Close();
            return forcatime;
        }
    }
