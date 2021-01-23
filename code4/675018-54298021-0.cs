    public class Program
    {
    string connection = "SERVER=localhost; user id=root; password=; database=dbname";
    private void Form1_Load(object sender, System.EventArgs e)
    {
    checkifconnected();
    }
    private void checkifconnected()
    {
    MySqlConnection connect = new MySqlConnection(connection);
    try{
    connect.Open();
    MessageBox.Show("Database connected");
    }
    catch
    {
    MessageBox.Show("you are not connected to database");
    }
    }
    public static void Main()
    {
    
    }
    }
